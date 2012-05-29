<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Data;
using System.IO;
using chiase.Objects;
using DK2C.DataAccess.Web;

public class Upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string userid = "";
            string allbumid = "";
            string savepath = "";
            string tempPath = "";
            tempPath = "images/upload";
            //tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"]; 
            string id = context.Request.QueryString["id"];
            string[] arrays = id.Split(';');
            userid = arrays[1];
            allbumid = arrays[0];
            
            string filename = postedFile.FileName;
            string path = tempPath + @"/" + filename;
            savepath = context.Server.MapPath(tempPath);
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            postedFile.SaveAs(savepath + @"/" + filename);

            
            
            //save images path to database
            string sql = @"insert into IMG_ALLBUM_DETAIL (allbum_id,path,title,status,posted_by,posted_date,liked) values(@allbum_id,@path,@title,@status,@posted_by,@posted_date,@liked)";
            SQLConnectWeb.ExecuteNonQuery(sql,
                        "@allbum_id", allbumid,
                        "@path", path,
                        "@title", filename,
                        "@status", 1,
                        "@posted_by", userid,
                        "@posted_date", functions.GetStringDatetime(),
                        "@liked", 0);
            
            
            
            context.Response.Write(tempPath + "/" + filename);
            context.Response.StatusCode = 200;
            
            
            

            
        }
        catch (Exception ex)
        {
            //context.Response.Write("Error: " + ex.Message);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}