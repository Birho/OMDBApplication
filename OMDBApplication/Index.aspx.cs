using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

namespace OMDBApplication
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                PopulateListBox.Populate(ListBoxMovie);
                ListBoxMovie.AutoPostBack = true;
                RadioButtonID.AutoPostBack = true;
                RadioButtonName.AutoPostBack = true;
            }
        }

        protected void Buttonfind_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string result = "";

            if(RadioButtonID.Checked)
            {
                if(RadioButtonJSON.Checked)
                {
                    result = client.DownloadString("http://www.omdbapi.com/?i=" + TextBoxInput.Text + "&apikey=" + TokenClass.token);
                }
                else
                {
                    result = client.DownloadString("http://www.omdbapi.com/?i=" + TextBoxInput.Text + "&r=xml&apikey=" + TokenClass.token);
                }
            }
            else
            {
                // substitute " " with "+"
                string myselection = TextBoxInput.Text.Replace(' ', '+');

                if (RadioButtonJSON.Checked)
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&apikey=" + TokenClass.token);
                }
                else
                {
                    result = client.DownloadString("http://www.omdbapi.com/?t=" + myselection + "&r=xml&apikey=" + TokenClass.token);
                }
            }

            if(RadioButtonJSON.Checked)
            {
                File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.json"), result);

                // A simple example. Treat json as a string
                string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
                string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

                if(mysplit[1] != "False")
                {
                    LabelMessages.Text = "Movie found";

                    for(int i = 0; i < mysplit.Length; i++)
                    {
                        if(mysplit[i] == "Poster")
                        {
                            ImagePoster.ImageUrl = mysplit[++i];
                            break;
                        }
                    }
                    LabelResult.Text = "Ratings : ";
                    for(int i = 0; i < mysplit.Length; i++)
                    {
                        if(mysplit[i] == "Ratings")
                        {
                            while(mysplit[++i] == "Source")
                            {
                                if (mysplit[i - 1] != "Ratings") LabelResult.Text += "; ";
                                LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
                                i = i + 3;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    LabelMessages.Text = "Movie not found";
                    ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
                    LabelResult.Text = "Result";
                }
            }
            else
            {
                File.WriteAllText(Server.MapPath("~/MyFiles/Latestresult.xml"), result);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                if(doc.SelectSingleNode("/root/@response").InnerText == "True")
                {
                    XmlNodeList nodelist = doc.SelectNodes("/root/movie");
                    foreach (XmlNode node in nodelist)
                    {
                        string id = node.SelectSingleNode("@poster").InnerText;
                        ImagePoster.ImageUrl = id;
                    }
                    LabelResult.Text = "Rating" + nodelist[0].SelectSingleNode("@imdbRating").InnerText;
                    LabelResult.Text += " from " + nodelist[0].SelectSingleNode("@imdbVotes").InnerText + "votes";
                }
                else
                {
                    LabelMessages.Text = "Movie not found";
                    ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
                    LabelResult.Text = "Result";
                }
            }

        }

        protected void ListBoxMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxInput.Text = ListBoxMovie.SelectedValue;
        }

        protected void RadioButtonName_CheckedChanged(object sender, EventArgs e)
        {
            ListBoxMovie.Enabled = false;
            ListBoxMovie.BackColor = Color.Silver;
            ListBoxMovie.SelectedIndex = 0;
            TextBoxInput.Text = "";
            ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
            LabelMessages.Text = "Message";
            LabelResult.Text = "Result";
        }

        protected void RadioButtonID_CheckedChanged(object sender, EventArgs e)
        {
            ListBoxMovie.Enabled = true;
            ListBoxMovie.BackColor = Color.White;
            ListBoxMovie.SelectedIndex = 0;
            TextBoxInput.Text = "";
            ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
            LabelMessages.Text = "Message";
            LabelResult.Text = "Result";
        }
    }
}