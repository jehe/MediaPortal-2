#region Copyright (C) 2007-2011 Team MediaPortal

/*
    Copyright (C) 2007-2011 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using MediaPortal.Core;
using MediaPortal.Core.Logging;
using MediaPortal.Core.MediaManagement;
using MediaPortal.Core.MediaManagement.ResourceAccess;

namespace MediaPortal.UiComponents.Media.Views.RemovableMediaDrives
{
  public enum VideoMediaType
  {
    Unknown,
    VideoBD,
    VideoDVD,
    VideoCD,
  }

  /// <summary>
  /// Drive handler for video BDs, DVDs and CDs. Creates one single media item for the video on the drive.
  /// </summary>
  public class VideoDriveHandler : BaseDriveHandler
  {
    #region Protected fields

    protected MediaItem _mediaItem;

    #endregion

    protected VideoDriveHandler(DriveInfo driveInfo, IEnumerable<Guid> extractedMIATypeIds) : base(driveInfo)
    {
        IMediaAccessor mediaAccessor = ServiceRegistration.Get<IMediaAccessor>();
        ResourcePath rp = LocalFsMediaProviderBase.ToProviderResourcePath(driveInfo.Name);
        using (IResourceAccessor ra = rp.CreateLocalResourceAccessor())
          _mediaItem = mediaAccessor.CreateMediaItem(ra, mediaAccessor.GetMetadataExtractorsForMIATypes(extractedMIATypeIds));
    }

    /// <summary>
    /// Creates a <see cref="VideoDriveHandler"/> if the drive of the given <paramref name="driveInfo"/> contains a video CD/DVD/BD.
    /// </summary>
    /// <param name="driveInfo">Drive info object for the drive to examine.</param>
    /// <param name="extractedMIATypeIds">Media item aspect types to be extracted from the video item. The given MIAs will be present
    /// in the created instance's <see cref="VideoItem"/>.</param>
    /// <returns><see cref="VideoDriveHandler"/> instance for the video CD/DVD/BD or <c>null</c>, if the given drive doesn't contain
    /// a video media.</returns>
    public static VideoDriveHandler TryCreateVideoDriveHandler(DriveInfo driveInfo,
        IEnumerable<Guid> extractedMIATypeIds)
    {
      VideoMediaType vmt;
      return DetectVideoMedia(driveInfo.Name, out vmt) ? new VideoDriveHandler(driveInfo, extractedMIATypeIds) : null;
    }

    /// <summary>
    /// Detects if a video CD/DVD/BD is contained in the given <paramref name="drive"/>.
    /// </summary>
    /// <param name="drive">The drive to be examined.</param>
    /// <param name="videoMediaType">Returns the type of the media found in the given <paramref name="drive"/>. This parameter
    /// only returns a sensible value when the return value of this method is <c>true</c>.</param>
    /// <returns><c>true</c>, if a video media was identified, else <c>false</c>.</returns>
    public static bool DetectVideoMedia(string drive, out VideoMediaType videoMediaType)
    {
      videoMediaType = VideoMediaType.Unknown;
      if (string.IsNullOrEmpty(drive) || drive.Length < 2)
        return false;
      drive = drive.Substring(0, 2); // Clip potential '\\' at the end

      if (Directory.Exists(drive + "\\BDMV"))
      {
        ServiceRegistration.Get<ILogger>().Info("RemovableMediaManager: BD inserted into drive {0}", drive);
        videoMediaType = VideoMediaType.VideoBD;
        return true;
      }

      if (Directory.Exists(drive + "\\VIDEO_TS"))
      {
        ServiceRegistration.Get<ILogger>().Info("RemovableMediaManager: DVD inserted into drive {0}", drive);
        videoMediaType = VideoMediaType.VideoDVD;
        return true;
      }

      if (Directory.Exists(drive + "\\MPEGAV"))
      {
        ServiceRegistration.Get<ILogger>().Info("RemovableMediaManager: Video CD inserted into drive {0}", drive);
        videoMediaType = VideoMediaType.VideoCD;
        return true;
      }
      return false;
    }

    public MediaItem VideoItem
    {
      get { return _mediaItem; }
    }

    #region IRemovableDriveHandler implementation

    public override IList<MediaItem> MediaItems
    {
      get { return new List<MediaItem>(1) {_mediaItem}; }
    }

    public override IList<ViewSpecification> SubViewSpecifications
    {
      get { return new List<ViewSpecification>(0); }
    }

    public override IEnumerable<MediaItem> GetAllMediaItems()
    {
      yield return _mediaItem;
    }

    #endregion
  }
}