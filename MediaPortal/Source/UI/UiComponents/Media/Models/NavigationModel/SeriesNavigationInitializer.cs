#region Copyright (C) 2007-2015 Team MediaPortal

/*
    Copyright (C) 2007-2015 Team MediaPortal
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

using System.Collections.Generic;
using MediaPortal.UiComponents.Media.General;
using MediaPortal.UiComponents.Media.Models.ScreenData;
using MediaPortal.UiComponents.Media.Models.Sorting;
using MediaPortal.Common.MediaManagement.DefaultItemAspects;
using System.Linq;
using MediaPortal.UiComponents.Media.Views;

namespace MediaPortal.UiComponents.Media.Models.NavigationModel
{
  internal class SeriesNavigationInitializer : BaseNavigationInitializer
  {
    internal static IEnumerable<string> RESTRICTED_MEDIA_CATEGORIES = new List<string> { Models.MediaNavigationMode.Series }; // "Series"

    public SeriesNavigationInitializer()
    {
      _mediaNavigationMode = Models.MediaNavigationMode.Series;
      _mediaNavigationRootState = Consts.WF_STATE_ID_SERIES_NAVIGATION_ROOT;
      _viewName = Consts.RES_SERIES_VIEW_NAME;
      _necessaryMias = Consts.NECESSARY_EPISODE_MIAS;
      _optionalMias = Consts.OPTIONAL_EPISODE_MIAS;
      _restrictedMediaCategories = RESTRICTED_MEDIA_CATEGORIES;
    }

    protected override void Prepare()
    {
      base.Prepare();
      _defaultScreen = new SeriesFilterByNameScreenData();
      _availableScreens = new List<AbstractScreenData>
      {
        new SeriesShowItemsScreenData(_genericPlayableItemCreatorDelegate),
        // C# doesn't like it to have an assignment inside a collection initializer
        _defaultScreen,
        new SeriesFilterBySeasonScreenData(),
        new VideosFilterByLanguageScreenData(),
        new VideosFilterByPlayCountScreenData(),
        new SeriesFilterByActorScreenData(),
        new VideosFilterByGenreScreenData(),
        new VideosSimpleSearchScreenData(_genericPlayableItemCreatorDelegate),
      };
      _defaultSorting = new SeriesSortByEpisode();
      _availableSortings = new List<Sorting.Sorting>
      {
        _defaultSorting,
        new SortByTitle(),
        new SortByFirstAiredDate(),
        new SortByDate(),
        new SortBySystem(),
      };
    }
  }
}
