using AestheticServicesMultiTool.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AestheticServicesMultiTool.Tools
{
    static class RankChanger
    {
        internal static int RankSurvival = 0;
        internal static int RankKiller = 0;
        private static Image[] img_rank_survival;
        private static Image[] img_rank_killer;
        internal static Image[] Img_RankSurvival { get => img_rank_survival; }
        internal static Image[] Img_RankKiller { get => img_rank_killer; }

        static RankChanger()
        {
            img_rank_survival = getFrames(Resources.Ranks_survivor_reversed);
            img_rank_killer = getFrames(Resources.Ranks_killer_reversed);
        }

        private static Image[] getFrames(Image originalImg)
        {
            int numberOfFrames = originalImg.GetFrameCount(System.Drawing.Imaging.FrameDimension.Time);
            Image[] frames = new Image[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                originalImg.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Time, i);
                frames[i] = ((Image)originalImg.Clone());
            }

            return frames;
        }
    }
}
