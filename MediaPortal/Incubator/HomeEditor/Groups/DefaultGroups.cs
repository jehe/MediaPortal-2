using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEditor.Groups
{
  public static class DefaultGroups
  {
    public const string DEFAULT_OTHERS_GROUP_NAME = "[HomeEditor.OthersMenuItem]";

    public static List<HomeMenuGroup> Create()
    {
      return new List<HomeMenuGroup>
      {
        new HomeMenuGroup("[Media.ImagesMenuItem]", new Guid("e9463404-ff36-4255-91fd-4742ecdbaf6a"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[Media.ImagesMenuItem]", new Guid("55556593-9fe9-436c-a3b6-a971e10c9d44"))
          }
        },
        new HomeMenuGroup("[Media.AudioMenuItem]", new Guid("b527e507-2b32-437d-8cd7-d670950bad39"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[Media.AudioMenuItem]", new Guid("30715d73-4205-417f-80aa-e82f0834171f")),
            new HomeMenuAction("[PartyMusicPlayer.MenuItem]", new Guid("e00b8442-8230-4d7b-b871-6ac77755a0d5"))
          }
        },
        new HomeMenuGroup("[Media.VideosMenuItem]", new Guid("99b80a99-419c-4fa8-97e1-1b4e6406e09a"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[Media.VideosMenuItem]", new Guid("a4df2df6-8d66-479a-9930-d7106525eb07")),
            new HomeMenuAction("[Media.MoviesMenuItem]", new Guid("80d2e2cc-baaa-4750-807b-f37714153751")),
            new HomeMenuAction("[Media.SeriesMenuItem]", new Guid("30f57cba-459c-4202-a587-09fff5098251")),
            new HomeMenuAction("OnlineVideos", new Guid("c33e39cc-910e-41c8-bffd-9eccd340b569")),
            new HomeMenuAction("[Media.BrowseMediaMenuItem]", new Guid("93442df7-186d-42e5-a0f5-cf1493e68f49"))
          }
        },
        new HomeMenuGroup("[SlimTvClient.Main]", new Guid("c556242c-a97d-4947-9821-b3e71f866836"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[SlimTvClient.Main]", new Guid("b4a9199f-6dd4-4bda-a077-de9c081f7703")),
            new HomeMenuAction("[SlimTvClient.TvGuide]", new Guid("a298dfbe-9da8-4c16-a3ea-a9b354f3910c")),
            new HomeMenuAction("[SlimTvClient.Schedules]", new Guid("87355e05-a15b-452a-85b8-98d4fc80034e")),
            new HomeMenuAction("[SlimTvClient.RecordingsMenuItem]", new Guid("7f52d0a1-b7f8-46a1-a56b-1110bbfb7d51")),
            new HomeMenuAction("[SlimTvClient.ProgramSearch]", new Guid("d91738e9-3f85-443b-abbd-ef01731734ad"))
          }
        },
        new HomeMenuGroup("[News.Title]", new Guid("f41d7acb-ea54-42d3-993c-e9770762931f"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[News.Title]", new Guid("bb49a591-7705-408f-8177-45d633fdfad0")),
            new HomeMenuAction("[Weather.Title]", new Guid("e34fdb62-1f3e-4aa9-8a61-d143e0af77b5"))
          }
        },
        new HomeMenuGroup("[Configuration.Name]", new Guid("df5a84b0-2de1-4dd2-b0bc-982751db9eeb"))
        {
          Actions = new List<HomeMenuAction>
          {
            new HomeMenuAction("[Configuration.Name]", new Guid("f6255762-c52a-4231-9e67-14c28735216e"))
          }
        },
      };
    }
  }
}