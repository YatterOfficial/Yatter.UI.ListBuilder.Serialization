using System;
using Newtonsoft.Json;
using Yatter.UI.ListBuilder.ListItems;

namespace Yatter.UI.ListBuilder.Serialization.Models
{
    public class YatterPath : IDataType
    {
        public string DataType { get; set; }

        public string Base64Icon { set; get; } = String.Empty;
        public string Base64IconType { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Path { get; set; } = String.Empty;
        public string PageLoaderKey { get; set; } = String.Empty;
        public string Mnemonic { get; set; } = String.Empty;

        [JsonIgnore]
        public string Tag { get; set; } = String.Empty;

        public YatterPath()
        {
            DataType = GetType().ToString();
            PageLoaderKey = "default";
            Base64Icon = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAABTVJREFUWEfNl31olVUcxz/neZ577+7unSxfJghOMltS2iBxJtQQS3szUYjwLYcuRPGFJI3eFFIhIcWwYQY5X7LyrxKjN4cjBMkU/5iztPXeonDGNt292+69zzknzrPd3d3d7d67EdQPnn8ezjm/7/n+Xr6/Iwrm7Nb8hyb+dwCEANuysnIilUbrdOKE0NgiO5lSC7QWaWenMWCcxxMKGY2BJWDgeWavBrvQj99n94EwzuPSQXYHoHdNuhdAgV0Qw++4aSD6AAghSMRdppSOYeEDdxJ3JZZB1M+U1t6/k2ebaP6rHZ/f8U5OJHxMHN3KovIrKLcHe9o+JfAHXE413sOPLSX4fIk+EP0AgJKaoqCPhuNrmDC2aMgw1F38hfkbjlMYDiBQRLsKOL32bebNaoIuoH8EFRCAP5tHUb5nKx1xP5ZQaI8qSAuBbVtEb3ZSWTGZM/uXY2JtD7iO+Rfw2VTt+oRjpy6Cr4SVM89xdNUJYh0OtmU8pkxqC9uveOittZxtuotQKIpUKYQZVeCBaIty6LXFrF5QjpQK8y9pJgzGbrRFmbqsFtw2rr28l3FFEfDoTyWOcWSHFbVfVVD9/gpC4Uia8wwGvB9CIF1JcVEBDe+toeS2Qs9h/3yQSnmVsv+jq9D0FJsWfIe8ZaXdXplsd6DlZpjyPVto7wpi2zJ7FSRv6dgWkfZOVi66j6OvPpnBglmntfTAcrUS3XoO4digZR9T3u1DiqrDSzh2fjbhUBS3H/XJhUM2IssSdEZinK5ZwbyZt5O8dZ8HLdHChs5GRMMMECb25tMezXahou5yGfMPrqOwoBuPkUEsK4BYd4KySWO5dHg1fp/jhSGtMs2NDYjml+C33eBz0MpFWcLrCzP2bqbp+ngC/vjwARiwjmMRaY2ybd1cdjxbiSsVJjwp06AV6Dg0TIeun5HY2GGX7R8/ws7PniAcjgxKfc4QeAnZ0/gQSnPhcDXTJo/LLM0kC+1fIBsfww7ZXPl9HBVvbkaLnmrP1qBzipFXlh3dzJ1lesMylNJYA7VCuyAc5A9LsVpP8PA7G6i/dgehYFdG2Q1Mg5wAvFB4VRGl5pWnWb/47kGqQmGExhZ/UHtgPdVH5hAaFUfKwROvP4g8AWgiHX5qltaxftNBpCjtVb6efEg2p5a2GOVVR2i/2YrtOBmKOawqSC42rTXaFWTu1J84s7YGNXoJ1pQPoZd2sy7ZLat2neLYyUuEi8NewuZjWRnoS0ItuPDcPqaV3kBGJfb0z6H4Ua/xeNRbFv0FyuRJvpYVgGMpIpEw2x7/lB2Lv0RGHGwkBCdDeSNa+FHaIp5wmbGqlqZf/yYQ9HmJmq8N3YiEJhb3Uzb+Opee34ffdrGURlgOJFyY9CLuxNdNu2f7u2fZeaCe8JgQrpsf9Tn7gFG1zu5enb+3CdmZFBsTGAspLezZl7nSXErFM/vQtpOz5vNOQo/6aIiV93/t6byMpiudab8yIbHGP8jDNRupP3+VULjAa1LDtYwQmPlOSpviYBcNW/dQMmoQnTe3L1LU1pdT/cFyQqMUMiWEw8KQOZCYsouEObT8OKvnXEBGsun8C706n5rxhuU9YyQzzqMhKsu+58zGg8i4he3JbMqM1AaK3Jw6ny+Q1FCK9kqqyB+nYcsbTJh4C2KDDJhBqPsmt84PH4DQ3ng9paSFhdO/JR5zsKz0pDI5ZqrwZMM0mltHe+P1UIPGsAF48mseGG7vA8O0+aEeJuaBYac/MPJ1mFMNR/rE+tcAjPSgke7LS45Heng++/4B9WZ7Hw4THAwAAAAASUVORK5CYII=";
            Base64IconType = "png";
        }

        public bool Equals(YatterPath path)
        {
            if(    path.Username.Equals(Username)
                && path.Path.Equals(Path)
                && path.PageLoaderKey.Equals(PageLoaderKey)
              )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [JsonIgnore]
        public Action<YatterPath> ClickAction { get; set; } = null;

        public void OnClick()
        {
            if(ClickAction!=null)
            {
                ClickAction.Invoke(this);
            }
        }
    }

    public static class YatterPathExtensionMethods
    {
        public static YatterPath AddBase64Icon(this YatterPath yatterPath, string base64Icon)
        {
            yatterPath.Base64Icon = base64Icon;
            return yatterPath;
        }

        public static YatterPath AddBase64IconType(this YatterPath yatterPath, string base64IconType)
        {
            yatterPath.Base64IconType = base64IconType;
            return yatterPath;
        }

        public static YatterPath AddTitle(this YatterPath yatterPath, string title)
        {
            yatterPath.Title = title;
            return yatterPath;
        }

        public static YatterPath AddUsername(this YatterPath yatterPath, string username)
        {
            yatterPath.Username = username.ToLower();
            return yatterPath;
        }

        public static YatterPath AddPath(this YatterPath yatterPath, string path)
        {
            yatterPath.Path = path.ToLower();
            return yatterPath;
        }

        public static YatterPath AddPageLoaderKey(this YatterPath yatterPath, string pageLoaderKey)
        {
            yatterPath.PageLoaderKey = pageLoaderKey;
            return yatterPath;
        }

        public static YatterPath AddMnemonic(this YatterPath yatterPath, string mnemonic)
        {
            yatterPath.Mnemonic = mnemonic;
            return yatterPath;
        }

        public static YatterPath AddClickAction(this YatterPath yatterPath, Action<YatterPath> clickAction)
        {
            yatterPath.ClickAction = clickAction;

            return yatterPath;
        }
    }
}

