
using UnityEngine;
using System.Collections;
using UnityEditor;

public class CinemaDirectorProductInfo : CinemaSuite.CinemaDirectorBaseProductInfo
{
    public CinemaDirectorProductInfo()
    {
        name = "Cinema Director";
        version = "1.4.4.0";
        installed = true;

        headerText = "<size=16>Cinema Director</size>";
        header2Text = string.Format("<size=14><b>v{0}</b> detected.</size>", version);
        bodyText = "Thank you for purchasing Cinema Director! We hope that you enjoy using the product and that it helps make your game dev project a success!\n\nIf you have a chance, please leave us a review on the Asset Store.";

        string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";
        resourceImage1 = Resources.Load("Cinema_Suite_Docs" + suffix) as Texture2D;
        resourceImage2 = Resources.Load("Cinema_Suite_Forums" + suffix) as Texture2D;
        resourceImage3 = Resources.Load("Cinema_Suite_Tips" + suffix) as Texture2D;
        resourceImage4 = Resources.Load("Cinema_Suite_Video" + suffix) as Texture2D;

        resourceImage1Link = "http://www.cinema-suite.com/Documentation/CinemaDirector/CinemaDirectorDocumentation.pdf";
        resourceImage2Link = "http://cinema-suite.com/forum/viewforum.php?f=13";
        resourceImage3Link = "https://www.youtube.com/playlist?list=PLkTFhf2jQXOnuPITh5hit_WP8BOktxm2j";
        resourceImage4Link = "https://youtu.be/nD9EIlTiaBQ";

        resourceImage1Label = "Docs";
        resourceImage2Label = "Forum";
        resourceImage3Label = "Tips";
        resourceImage4Label = "Tutorial";

        assetStorePage = "http://u3d.as/8vm";
    }
}
