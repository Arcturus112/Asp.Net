using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.AdminPanel.File_Uplode
{
    public partial class FileUplode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(fuFile.HasFile)
            {
                #region File Details
                #region Bytes to Kilo Bytes
                string filename = Path.GetFileName(fuFile.PostedFile.FileName);
                string extension = Path.GetExtension(filename);
                string[] sizes = { "B", "KB", "MB", "GB" };
                double sizeinbytes = fuFile.FileBytes.Length;
                int order = 0;
                while (sizeinbytes >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    sizeinbytes = sizeinbytes / 1024;
                }
                string result = String.Format("{0:0.##} {1}", sizeinbytes, sizes[order]);
                #endregion Bytes to Kilo Bytes

                lblMassage.Text = "File FileName - " + fuFile.FileName.ToString().Trim() + "<br/>";
                lblMassage.Text += "&emsp;&emsp;&emsp;" + "File Size - " + result + "<br/>";
                lblMassage.Text += "&emsp;&emsp;&emsp;" + "File contentType  - " + fuFile.PostedFile.ContentType + "<br/>";
                lblMassage.Text += "&emsp;&emsp;&emsp;" + "File extension  - " + extension + "<br/>";
                #endregion File Details

                string FolderPath = "../../UserContent/";
                string AbsolutePath =  Server.MapPath(FolderPath);
                lblMassage.Text += "&emsp;&emsp;&emsp;" + "File Location :" + AbsolutePath ;

                if (!Directory.Exists(AbsolutePath))
                {
                    Directory.CreateDirectory(AbsolutePath);
                }

                fuFile.SaveAs(AbsolutePath + fuFile.FileName.ToString().Trim());

            }
            else
            {
                lblMassage.Text = "Kindly Select File";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String FilePath = "../../UserContent/cn1.png";
            FileInfo file = new FileInfo(Server.MapPath(FilePath));
            if (file.Exists)
            {
                file.Delete();
                lblMassage.Text = "File is Deleted successfully";
            }
            else
            {
                lblMassage.Text = "File is Not Available";
            }
        }
    }
}



