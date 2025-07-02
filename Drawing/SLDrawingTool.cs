using System;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using A = DocumentFormat.OpenXml.Drawing;

namespace SpreadsheetLight.Drawing
{
    internal class SLDrawingTool
    {
        internal static PartTypeInfo GetImagePartType(string ImageFileName)
        {
            PartTypeInfo ipt = ImagePartType.Png;

            switch (ImageFileName.Substring(ImageFileName.LastIndexOf(".") + 1).ToLowerInvariant())
            {
                case "bmp":
                    ipt = ImagePartType.Bmp;
                    break;
                case "emf":
                    ipt = ImagePartType.Emf;
                    break;
                case "gif":
                    ipt = ImagePartType.Gif;
                    break;
                case "ico":
                    ipt = ImagePartType.Icon;
                    break;
                case "jpg":
                case "jpeg":
                    ipt = ImagePartType.Jpeg;
                    break;
                case "pcx":
                    ipt = ImagePartType.Pcx;
                    break;
                case "png":
                    ipt = ImagePartType.Png;
                    break;
                case "tif":
                case "tiff":
                    ipt = ImagePartType.Tiff;
                    break;
                case "wmf":
                    ipt = ImagePartType.Wmf;
                    break;
            }

            return ipt;
        }

        internal static SLThemeColorIndexValues TranslateSchemeColorValue(A.SchemeColorValues Color)
        {
            SLThemeColorIndexValues theme = SLThemeColorIndexValues.Dark1Color;

            if (Color == SchemeColorValues.Accent1)
            {
                theme = SLThemeColorIndexValues.Accent1Color;
            }
            else if (Color == SchemeColorValues.Accent2)
            {
                theme = SLThemeColorIndexValues.Accent2Color;
            }
            else if (Color == SchemeColorValues.Accent3)
            {
                theme = SLThemeColorIndexValues.Accent3Color;
            }
            else if (Color == SchemeColorValues.Accent4)
            {
                theme = SLThemeColorIndexValues.Accent4Color;
            }
            else if (Color == SchemeColorValues.Accent5)
            {
                theme = SLThemeColorIndexValues.Accent5Color;
            }
            else if (Color == SchemeColorValues.Accent6)
            {
                theme = SLThemeColorIndexValues.Accent6Color;
            }
            else if (Color == SchemeColorValues.Background1)
            {
                theme = SLThemeColorIndexValues.Light1Color;
            }
            else if (Color == SchemeColorValues.Background2)
            {
                theme = SLThemeColorIndexValues.Light2Color;
            }
            else if (Color == SchemeColorValues.Dark1)
            {
                theme = SLThemeColorIndexValues.Dark1Color;
            }
            else if (Color == SchemeColorValues.Dark2)
            {
                theme = SLThemeColorIndexValues.Dark2Color;
            }
            else if (Color == SchemeColorValues.FollowedHyperlink)
            {
                theme = SLThemeColorIndexValues.FollowedHyperlinkColor;
            }
            else if (Color == SchemeColorValues.Hyperlink)
            {
                theme = SLThemeColorIndexValues.Hyperlink;
            }
            else if (Color == SchemeColorValues.Light1)
            {
                theme = SLThemeColorIndexValues.Light1Color;
            }
            else if (Color == SchemeColorValues.Light2)
            {
                theme = SLThemeColorIndexValues.Light2Color;
            }
            else if (Color == SchemeColorValues.PhColor)
            {
                // I don't know what this...
                theme = SLThemeColorIndexValues.Dark1Color;
            }
            else if (Color == SchemeColorValues.Text1)
            {
                theme = SLThemeColorIndexValues.Dark1Color;
            }
            else if (Color == SchemeColorValues.Text2)
            {
                theme = SLThemeColorIndexValues.Dark2Color;
            }

            return theme;
        }


        internal static int CalculateAlpha(decimal Transparency)
        {
            if (Transparency > 100m) Transparency = 100m;
            if (Transparency < 0m) Transparency = 0m;
            return Convert.ToInt32((100m - Transparency) * 1000m);
        }

        internal static int CalculatePercentage(decimal Size)
        {
            return Convert.ToInt32(Size * 1000m);
        }

        internal static long CalculateCoordinate(decimal PointLength)
        {
            if (PointLength < -2147483648m) PointLength = -2147483648m;
            if (PointLength > 2147483647m) PointLength = 2147483647m;
            return Convert.ToInt64(PointLength * (decimal)SLConstants.PointToEMU);
        }

        internal static long CalculatePositiveCoordinate(decimal PointLength)
        {
            if (PointLength < 0m) PointLength = 0m;
            // 2147483647 = 2^31 - 1
            if (PointLength > 2147483647m) PointLength = 2147483647m;
            return Convert.ToInt64(PointLength * (decimal)SLConstants.PointToEMU);
        }

        internal static int CalculatePositiveFixedAngle(decimal Angle)
        {
            int iAngle = Convert.ToInt32(Angle * (decimal)SLConstants.DegreeToAngleRepresentation);
            if (iAngle < 0) iAngle = 0;
            if (iAngle >= 21600000) iAngle = (21600000 - 1);
            return iAngle;
        }

        internal static int CalculateFixedAngle(decimal Angle)
        {
            int iAngle = Convert.ToInt32(Angle * (decimal)SLConstants.DegreeToAngleRepresentation);
            if (iAngle <= -5400000) iAngle = (-5400000 + 1);
            if (iAngle >= 5400000) iAngle = (5400000 - 1);
            return iAngle;
        }

        internal static int CalculatePositiveFixedPercentage(decimal Percentage)
        {
            if (Percentage < 0m) Percentage = 0m;
            if (Percentage > 100m) Percentage = 100m;
            return Convert.ToInt32(Percentage * 1000m);
        }

        internal static int CalculateFovAngle(decimal Angle)
        {
            if (Angle < 0m) Angle = 0m;
            if (Angle > 180m) Angle = 180m;
            return Convert.ToInt32(Angle * (decimal)SLConstants.DegreeToAngleRepresentation);
        }

        internal static string ConvertToVmlTitle(A.PresetPatternValues Preset)
        {
            if (Preset == A.PresetPatternValues.Cross)
            {
                // this isn't in the list, so I don't know the actual text. We'll guess...
                return "Cross";
            }
            else if (Preset == A.PresetPatternValues.DarkDownwardDiagonal)
            {
                return "Dark downward diagonal";
            }
            else if (Preset == A.PresetPatternValues.DarkHorizontal)
            {
                return "Dark horizontal";
            }
            else if (Preset == A.PresetPatternValues.DarkUpwardDiagonal)
            {
                return "Dark upward diagonal";
            }
            else if (Preset == A.PresetPatternValues.DarkVertical)
            {
                return "Dark vertical";
            }
            else if (Preset == A.PresetPatternValues.DashedDownwardDiagonal)
            {
                return "Dashed downward diagonal";
            }
            else if (Preset == A.PresetPatternValues.DashedHorizontal)
            {
                return "Dashed horizontal";
            }
            else if (Preset == A.PresetPatternValues.DashedUpwardDiagonal)
            {
                return "Dashed upward diagonal";
            }
            else if (Preset == A.PresetPatternValues.DashedVertical)
            {
                return "Dashed vertical";
            }
            else if (Preset == A.PresetPatternValues.DiagonalBrick)
            {
                return "Diagonal brick";
            }
            else if (Preset == A.PresetPatternValues.DiagonalCross)
            {
                // this isn't in the list, so I don't know the actual text. We'll guess...
                return "Diagonal cross";
            }
            else if (Preset == A.PresetPatternValues.Divot)
            {
                return "Divot";
            }
            else if (Preset == A.PresetPatternValues.DotGrid)
            {
                return "Dotted grid";
            }
            else if (Preset == A.PresetPatternValues.DottedDiamond)
            {
                return "Dotted diamond";
            }
            else if (Preset == A.PresetPatternValues.DownwardDiagonal)
            {
                return "Downward diagonal";
            }
            else if (Preset == A.PresetPatternValues.Horizontal)
            {
                return "Horizontal";
            }
            else if (Preset == A.PresetPatternValues.HorizontalBrick)
            {
                return "Horizontal brick";
            }
            else if (Preset == A.PresetPatternValues.LargeCheck)
            {
                return "Large checker board";
            }
            else if (Preset == A.PresetPatternValues.LargeConfetti)
            {
                return "Large confetti";
            }
            else if (Preset == A.PresetPatternValues.LargeGrid)
            {
                return "Large grid";
            }
            else if (Preset == A.PresetPatternValues.LightDownwardDiagonal)
            {
                return "Light downward diagonal";
            }
            else if (Preset == A.PresetPatternValues.LightHorizontal)
            {
                return "Light horizontal";
            }
            else if (Preset == A.PresetPatternValues.LightUpwardDiagonal)
            {
                return "Light upward diagonal";
            }
            else if (Preset == A.PresetPatternValues.LightVertical)
            {
                return "Light vertical";
            }
            else if (Preset == A.PresetPatternValues.NarrowHorizontal)
            {
                return "Narrow horizontal";
            }
            else if (Preset == A.PresetPatternValues.NarrowVertical)
            {
                return "Narrow vertical";
            }
            else if (Preset == A.PresetPatternValues.OpenDiamond)
            {
                return "Outlined diamond";
            }
            else if (Preset == A.PresetPatternValues.Percent10)
            {
                return "10%";
            }
            else if (Preset == A.PresetPatternValues.Percent20)
            {
                return "20%";
            }
            else if (Preset == A.PresetPatternValues.Percent25)
            {
                return "25%";
            }
            else if (Preset == A.PresetPatternValues.Percent30)
            {
                return "30%";
            }
            else if (Preset == A.PresetPatternValues.Percent40)
            {
                return "40%";
            }
            else if (Preset == A.PresetPatternValues.Percent5)
            {
                return "5%";
            }
            else if (Preset == A.PresetPatternValues.Percent50)
            {
                return "50%";
            }
            else if (Preset == A.PresetPatternValues.Percent60)
            {
                return "60%";
            }
            else if (Preset == A.PresetPatternValues.Percent70)
            {
                return "70%";
            }
            else if (Preset == A.PresetPatternValues.Percent75)
            {
                return "75%";
            }
            else if (Preset == A.PresetPatternValues.Percent80)
            {
                return "80%";
            }
            else if (Preset == A.PresetPatternValues.Percent90)
            {
                return "90%";
            }
            else if (Preset == A.PresetPatternValues.Plaid)
            {
                return "Plaid";
            }
            else if (Preset == A.PresetPatternValues.Shingle)
            {
                return "Shingle";
            }
            else if (Preset == A.PresetPatternValues.SmallCheck)
            {
                return "Small checker board";
            }
            else if (Preset == A.PresetPatternValues.SmallConfetti)
            {
                return "Small confetti";
            }
            else if (Preset == A.PresetPatternValues.SmallGrid)
            {
                return "Small grid";
            }
            else if (Preset == A.PresetPatternValues.SolidDiamond)
            {
                return "Solid diamond";
            }
            else if (Preset == A.PresetPatternValues.Sphere)
            {
                return "Sphere";
            }
            else if (Preset == A.PresetPatternValues.Trellis)
            {
                return "Trellis";
            }
            else if (Preset == A.PresetPatternValues.UpwardDiagonal)
            {
                return "Upward diagonal";
            }
            else if (Preset == A.PresetPatternValues.Vertical)
            {
                return "Vertical";
            }
            else if (Preset == A.PresetPatternValues.Wave)
            {
                return "Wave";
            }
            else if (Preset == A.PresetPatternValues.Weave)
            {
                return "Weave";
            }
            else if (Preset == A.PresetPatternValues.WideDownwardDiagonal)
            {
                return "Wide downward diagonal";
            }
            else if (Preset == A.PresetPatternValues.WideUpwardDiagonal)
            {
                return "Wide upward diagonal";
            }
            else if (Preset == A.PresetPatternValues.ZigZag)
            {
                return "Zig zag";
            }
            return string.Empty;
        }

        internal static System.Drawing.Bitmap GetVmlPatternFill(A.PresetPatternValues Preset)
        {
            // why did I generate the bitmap instead of cramping images as resources?
            // Because I don't wanna get sued by Microsoft. Even if the image files aren't copyrighted.
            // Even if I didn't use the original image files and painstakingly recreated them.
            // So I use a proxy, by generating them in-program instead.

            // Generating textures for use in a program during run-time? I feel like part
            // of the demoscene already. :)

            // Note that for 6 of the textures, I don't know what Microsoft Excel renders for them.
            // Even Microsoft Excel doesn't render them.
            // They are Cross, DiagonalCross, DownwardDiagonal, Horizontal, UpwardDiagonal and Vertical.
            // So why does PresetPatternValues enumeration have them? I don't know. Ask Microsoft.
            // So what happens is I generate my own version.
            // Oh relax, on the Excel user interface, these 6 options aren't available.
            // So you won't (probably) be subjected to my artistic talents.

            // Uh so how did I get these pixel values? Exercise, eating lots of vegetables,
            // and tons of painstakingly hard work. Hint: it involves writing code to process
            // image files and turn them into case statements. Then pasting said code case
            // statements here.
            // You think I'm gonna type them out with SetPixel()? Don't be ridiculous.

            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(8, 8);

            if (Preset == A.PresetPatternValues.Cross)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DarkDownwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.DarkHorizontal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DarkUpwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.DarkVertical)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DashedDownwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DashedHorizontal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DashedUpwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DashedVertical)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DiagonalBrick)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.DiagonalCross)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Divot)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DotGrid)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DottedDiamond)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.DownwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Horizontal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.HorizontalBrick)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.LargeCheck)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.LargeConfetti)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.LargeGrid)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.LightDownwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.LightHorizontal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.LightUpwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.LightVertical)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.NarrowHorizontal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.NarrowVertical)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.OpenDiamond)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent10)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Percent20)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Percent25)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Percent30)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent40)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent5)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Percent50)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent60)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent70)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent75)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent80)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Percent90)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.Plaid)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Shingle)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.SmallCheck)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.SmallConfetti)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.SmallGrid)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.SolidDiamond)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Sphere)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Trellis)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.UpwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Vertical)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Wave)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }
            else if (Preset == A.PresetPatternValues.Weave)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.WideDownwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.WideUpwardDiagonal)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
            }
            else if (Preset == A.PresetPatternValues.ZigZag)
            {
                bm.SetPixel(0, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(0, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(0, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(1, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(1, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(2, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(2, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(3, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(3, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 3, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(4, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(4, 7, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 2, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(5, 6, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(5, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 0, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 1, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 4, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 5, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(6, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(6, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 0, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 1, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 2, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 3, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 4, System.Drawing.Color.FromArgb(255, 255, 255, 255));
                bm.SetPixel(7, 5, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 6, System.Drawing.Color.FromArgb(255, 0, 0, 0));
                bm.SetPixel(7, 7, System.Drawing.Color.FromArgb(255, 0, 0, 0));
            }

            return bm;
        }
    }
}
