﻿using EADPPROJ.App_Code;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EADPPROJ
{
    public partial class blog : System.Web.UI.Page
    {
        Profile profile = new Profile();
        Blog blog1 = new Blog();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.DataBind();
            if (ListView1.Items.Count != 0)
            {
                for (int i = 0; i < ListView1.Items.Count; i++)
                {
                    Label Default = (Label)ListView1.Items[i].FindControl("Default");
                    Label id = (Label)ListView1.Items[i].FindControl("BlogId");
                    HtmlGenericControl BG = (HtmlGenericControl)ListView1.Items[i].FindControl("BlogImg");
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog1.GetBGPath(Convert.ToInt32(id.Text)) + ")";
                    }
                    else
                    {
                        BG.Style["background-image"] = "url(../assets/img/examples/office2.jpg);";
                    }
                }
            }

            if (Session["Success"] != null)
            {
                addFav.Visible = true;
                Session["Success"] = null;
            }
            if (Session["Warn"] != null)
            {
                cannotFavAgain.Visible = true;
                Session["Warn"] = null;
            }
            GridView1.DataBind();
            GridView2.DataBind();
            GridView3.DataBind();
            GridView4.DataBind();
            if (GridView1.Rows.Count != 0)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    Label Default = (Label)GridView1.Rows[i].Cells[0].FindControl("Default");
                    HtmlGenericControl BG = (HtmlGenericControl)GridView1.Rows[i].Cells[0].FindControl("BlogImg");
                    Label id = (Label)GridView1.Rows[i].Cells[0].FindControl("BlogId");
                    LinkButton url = (LinkButton)GridView1.Rows[i].Cells[0].FindControl("Url");
                    url.PostBackUrl = "./blogDetail.aspx?id=" + id.Text;
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog1.GetBGPath(Convert.ToInt32(id.Text)) + ")";
                    }
                    else
                    {
                        BG.Style["background-image"] = "url(../assets/img/examples/card-project6.jpg)";
                    }
                }
            }
            
            if (GridView2.Rows.Count != 0)
            {
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    Label Default = (Label)GridView2.Rows[i].Cells[0].FindControl("Default");
                    HtmlGenericControl BG = (HtmlGenericControl)GridView2.Rows[i].Cells[0].FindControl("BlogImg");
                    Label id = (Label)GridView2.Rows[i].Cells[0].FindControl("BlogId");
                    LinkButton url = (LinkButton)GridView2.Rows[i].Cells[0].FindControl("Url");
                    url.PostBackUrl = "./blogDetail.aspx?id=" + id.Text;
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog1.GetBGPath(Convert.ToInt32(id.Text)) + ")";
                    }
                    else
                    {
                        BG.Style["background-image"] = "url(../assets/img/examples/card-project6.jpg)";
                    }
                }
            }

            if (GridView3.Rows.Count != 0)
            {
                for (int i = 0; i < GridView3.Rows.Count; i++)
                {
                    Label Default = (Label)GridView3.Rows[i].Cells[0].FindControl("Default");
                    HtmlGenericControl BG = (HtmlGenericControl)GridView3.Rows[i].Cells[0].FindControl("BlogImg");
                    Label id = (Label)GridView3.Rows[i].Cells[0].FindControl("BlogId");
                    LinkButton url = (LinkButton)GridView3.Rows[i].Cells[0].FindControl("Url");
                    url.PostBackUrl = "./blogDetail.aspx?id=" + id.Text;
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog1.GetBGPath(Convert.ToInt32(id.Text)) + ")";
                    }
                    else
                    {
                        BG.Style["background-image"] = "url(../assets/img/examples/card-project6.jpg)";
                    }
                }
            }
            if (GridView4.Rows.Count != 0)
            {
                for (int i = 0; i < GridView4.Rows.Count; i++)
                {
                    Label Default = (Label)GridView4.Rows[i].Cells[0].FindControl("Default");
                    HtmlGenericControl BG = (HtmlGenericControl)GridView4.Rows[i].Cells[0].FindControl("BlogImg");
                    Label id = (Label)GridView4.Rows[i].Cells[0].FindControl("BlogId");
                    LinkButton url = (LinkButton)GridView4.Rows[i].Cells[0].FindControl("Url");
                    url.PostBackUrl = "./blogDetail.aspx?id=" + id.Text;
                    if (Convert.ToInt32(Default.Text) == 0)
                    {
                        BG.Style["background-image"] = "url(../assets/img/BlogBG/" + blog1.GetBGPath(Convert.ToInt32(id.Text)) + ")";
                    }
                    else
                    {
                        BG.Style["background-image"] = "url(../assets/img/examples/card-project6.jpg)";
                    }
                }
            }

            
        }

        protected void addFav_Click(object sender, EventArgs e)
        {
            LinkButton add = (LinkButton)sender;
            GridViewRow row = (GridViewRow)add.NamingContainer;
            Label BlogId = (Label)row.Cells[0].FindControl("BlogId");
            if (profile.ValidateFav(profile, Convert.ToInt32(BlogId.Text), Session["Account"].ToString()) == 0)
            {
                profile.AddFavorite(profile, Convert.ToInt32(BlogId.Text), Session["Account"].ToString());
                blog1.AddFavourite(Convert.ToInt32(BlogId.Text));
                Session["Success"] = true;
                Response.Redirect("./blog.aspx");
            }
            else
            {
                Session["Warn"] = true;
                Response.Redirect("./blog.aspx");
            }

        }
    }
}