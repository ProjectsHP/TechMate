using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class BuildComputer : System.Web.UI.Page
    {

        ServiceClient SRef = new ServiceClient();
        string selectedComp = "";
        int total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string dispCompDet = "";
           
            int style = 1;
          

           dynamic build =  SRef.FetchBuildSOAP("2");

            if (build != null)
            {
                int index = 0;
                Component desktop = null; 
                Component cpu = null ;
                Component storage = null;
                Component ram = null;
                Component graphics = null;

                foreach (Component item in build)
                {
                    switch (item.category)
                    {
                        case "Desktop":

                            desktop = item as Component;
                            break;

                        case "CPU":
                             cpu = item as Component;
                            break;

                        case "Storage":
                             storage = item as Component;
                            break;

                        case "Ram":
                             ram = item as Component;
                            break;

                        case "Graphics":
                             graphics = item as Component;
                            break;
                    }
                }

                for (int i = 0; i < 5; i++)
                {

                    switch (i)
                    {
                        case 0:
                            dispCompDet += "<div class='o-lecturers-teacher active style-" + style + " position-center-x'>";
                            dispCompDet += "<a href='#itemslide" + i + "'class='o-teacher-img'>";
                            dispCompDet += "<img src='Content/images/products/components/" + cpu.image + "' style='width:150px; height:150px' alt='Alaxander Louise'></a>";
                            dispCompDet += "</div>";
                            break;

                        case 1:
                            dispCompDet += "<div class='o-lecturers-teacher style-" + style + " position-center-x'>";
                            dispCompDet += "<a href='#itemslide" + i + "' class='o-teacher-img'>";
                            dispCompDet += "<img src='Content/images/products/components/" + desktop.image + "' style='width:150px; height:150px' alt='Alaxander Louise'></a>";
                            dispCompDet += "</div>";
                            break;

                        case 2:
                            dispCompDet += "<div class='o-lecturers-teacher style-" + style + " position-center-y'>";
                            dispCompDet += "<a href='#itemslide" + i + "' class='o-teacher-img'>";
                            dispCompDet += "<img src='Content/images/products/components/" + graphics.image + "' style='width:150px; height:150px' alt='Alaxander Louise'></a>";
                            dispCompDet += "</div>";
                            break;

                        case 3:
                            dispCompDet += "<div class='o-lecturers-teacher style-" + style + " position-center-x'>";
                            dispCompDet += "<a href='#itemslide" + i + "' class='o-teacher-img'>";
                            dispCompDet += "<img src='Content/images/products/components/" + ram.image + "' style='width:150px; height:150px' alt='Alaxander Louise'></a>";
                            dispCompDet += "</div>";
                            break;

                        case 4:
                            dispCompDet += "<div class='o-lecturers-teacher style-" + style + " position-center-x'>";
                            dispCompDet += "<a href='#itemslide" + i + "' class='o-teacher-img'>";
                            dispCompDet += "<img src='Content/images/products/components/" + storage.image + "' style='width:150px; height:150px' alt='Alaxander Louise'></a>";
                            dispCompDet += "</div>";
                            break;




                    }

                
                    style++;
                }

                dispCompDet += "<div class='o-slider-detail o-teacher-detail position-center-y'>";


                foreach(Component c in build)
                {
                    dispCompDet += "<div class='o-slide-item' data-hash='itemslide" + index + "'>";
                    dispCompDet += "<div class='detail-teacher-img'>";
                    dispCompDet += "<img src='Content/images/products/components/" + c.image + "'alt='Alaxander Louise' style='width:350px; height:430px'>";
                    dispCompDet += "</div>";
                    dispCompDet += "<div class='teacher-detail'>";
                    dispCompDet += "<h3>"+c.category+"<span>"+c.name+"</span></h3>";
                    dispCompDet += "<p>"+c.description+"</p>";
                    dispCompDet += "<a class='btn' runat='server' href='SelectComponent.aspx?category="+c.category+"'>Choose "+c.category+"</a>";
                    dispCompDet += "</div>";
                    dispCompDet += "</div>";
                    index++;
                }

        
                dispCompDet += " </div>";

                showPartsDet.InnerHtml = dispCompDet;

            }

              createBuild();

            if (Session["Desktop_build"] != null)
            {
                var desktop = SRef.FetchComponentSOAP(Session["Desktop_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>"+desktop.category+"</h5>";
                selectedComp += "<p>"+desktop.name+"</p>";
                selectedComp += "<a href = '#'>R"+desktop.price+"</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + desktop.image+"'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)desktop.intPriceFormat;
              
               // Session["BuildTotPrice"] += price;

            }
            if (Session["CPU_build"] != null)
            {
                var cpu = SRef.FetchComponentSOAP(Session["CPU_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + cpu.category + "</h5>";
                selectedComp += "<p>" + cpu.name + "</p>";
                selectedComp += "<a href = '#'>R" + cpu.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + cpu.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)cpu.intPriceFormat;
              //  Session["BuildTotPrice"] += cpu.price;
            }
            if (Session["Ram_build"] != null)
            {
                var ram = SRef.FetchComponentSOAP(Session["Ram_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + ram.category + "</h5>";
                selectedComp += "<p>" + ram.name + "</p>";
                selectedComp += "<a href = '#'>R" + ram.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + ram.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total+=(int)ram.intPriceFormat;
               // Session["BuildTotPrice"] += ram.price;
            }
            if (Session["Storage_build"] != null)
            {
                var storage = SRef.FetchComponentSOAP(Session["Storage_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + storage.category + "</h5>";
                selectedComp += "<p>" + storage.name + "</p>";
                selectedComp += "<a href = '#'>R" + storage.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + storage.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)storage.intPriceFormat;
               // Session["BuildTotPrice"] += storage.price;
            }
            if (Session["Graphics_build"] != null)
            {
                var graphics = SRef.FetchComponentSOAP(Session["Graphics_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + graphics.category + "</h5>";
                selectedComp += "<p>" + graphics.name + "</p>";
                selectedComp += "<a href = '#'>R" + graphics.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + graphics.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)graphics.intPriceFormat;
                //Session["BuildTotPrice"] += graphics.price;
            }

            if (total!=0)
            {
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>Build details:</h5>";
                selectedComp += "<p>This build is compitable with all selected components. No issues detected</p>";
                selectedComp += "<a href = '#'>Total: R"+total+"</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<div class='icon'><i class='fa fa-laptop'></i></div>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
            }
           



            shBuild.InnerHtml = selectedComp;
            


        }


        protected void btnBuildComputer_Click(object sender, EventArgs e)
        {

            if (verifyNullSessions() == false)
            {
                string ram = Session["Ram_build"].ToString();
                string cpu = Session["CPU_build"].ToString();
                string storage = Session["Storage_build"].ToString();
                string desktop = Session["Desktop_build"].ToString();
                string user = Session["LoggedUser"].ToString();
                string graphics = Session["Graphics_build"].ToString();
                string totPrice = Convert.ToString(total);
                int response = SRef.CreateBuildSOAP(user, desktop, cpu, storage, graphics, ram, "Compatible",totPrice);
                if (response !=-1)
                {
                    Session.Remove("Ram_build");
                    Session.Remove("CPU_build");
                    Session.Remove("Storage_build");
                    Session.Remove("Graphics_build");
                    Session.Remove("Desktop_build");
                    Session["ActiveBuild"] = response;
                    Response.Redirect("Cart.aspx");
                }
            }
         
     

        }

        public void createBuild()
        {
            if (Request.QueryString["Desktop_build"] != null)
            {
             
                Session["Desktop_build"] = Request.QueryString["Desktop_build"].ToString();
            }
            if (Request.QueryString["CPU_build"] != null)
            {
               
                Session["CPU_build"] = Request.QueryString["CPU_build"].ToString();

            }
            if (Request.QueryString["Ram_build"] != null)
            {
               
                Session["Ram_build"] = Request.QueryString["Ram_build"].ToString();

            }
            if (Request.QueryString["Storage_build"] != null)
            {
                
                Session["Storage_build"] = Request.QueryString["Storage_build"].ToString();

            }
            if (Request.QueryString["Graphics_build"] != null)
            {
             
                Session["Graphics_build"] = Request.QueryString["Graphics_build"].ToString();

            }
          

     

        }

        public bool verifyNullSessions()
        {
            if (Session["Desktop_build"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build is not complete, please select a base desktop.')", true);
                return true;
            }
            else if(Session["CPU_build"] == null){
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build is not complete, please select a Processor.')", true);
                return true;
            }
            else if (Session["Storage_build"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build is not complete, please select a Storage.')", true);
                return true;
            }
            else if (Session["Graphics_build"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build is not complete, please select a Graphics card.')", true);
                return true;
            }
            else if (Session["LoggedUser"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please login to save and continue with your build')", true);
                return true;
            }


            return false;
        }
    }
}