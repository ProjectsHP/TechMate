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
              Compatibility case2verify = null;
            if (Session["Desktop_build"] != null)
            {
                var desktop = SRef.FetchComponentSOAP(Session["Desktop_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>"+desktop.category+"</h5>";
                selectedComp += "<p>"+desktop.name+"</p>";
                selectedComp += "<h6>In stock</h6>";
                selectedComp += "<a href = '#'>R"+desktop.price+"</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + desktop.image+"'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)desktop.intPriceFormat;
                string dId= Convert.ToString(desktop.Id);
                case2verify = SRef.FetchCaseCompatibilitySOAP(dId);

            }
            if (Session["CPU_build"] != null)
            {
                var cpu = SRef.FetchComponentSOAP(Session["CPU_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + cpu.category + "</h5>";
                selectedComp += "<p>" + cpu.name + "</p>";
                if (case2verify != null)
                {
                    if (case2verify.cpuType == cpu.compatibility)
                    {
                        selectedComp += "<h6 style='color:green'>Compatible</h6>";
                    }
                    else
                    {
                        selectedComp += "<h6 style='color:orangered'>Not Compatible</h6>";
                    }
                }
                selectedComp += "<a href = '#'>R" + cpu.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + cpu.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)cpu.intPriceFormat;
               
      
            }
            if (Session["Ram_build"] != null)
            {
                var ram = SRef.FetchComponentSOAP(Session["Ram_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + ram.category + "</h5>";
                selectedComp += "<p>" + ram.name + "</p>";
                if (case2verify != null)
                {
                    if (case2verify.ramType == ram.compatibility)
                    {
                        selectedComp += "<h6 style='color:green'>Compatible</h6>";
                    }
                    else
                    {
                        selectedComp += "<h6 style='color:orangered'>Not Compatible</h6>";
                    }
                }
                selectedComp += "<a href = '#'>R" + ram.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + ram.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total+=(int)ram.intPriceFormat;
    
            }
            if (Session["Storage_build"] != null)
            {
                var storage = SRef.FetchComponentSOAP(Session["Storage_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + storage.category + "</h5>";
                selectedComp += "<p>" + storage.name + "</p>";
                if (case2verify != null)
                {
                    if (case2verify.storageType == storage.compatibility)
                    {
                        selectedComp += "<h6 style='color:green'>Compatible</h6>";
                    }
                    else
                    {
                        selectedComp += "<h6 style='color:orangered'>Not Compatible</h6>";
                    }
                }
                selectedComp += "<a href = '#'>R" + storage.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + storage.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)storage.intPriceFormat;
   
            }
            if (Session["Graphics_build"] != null)
            {
                var graphics = SRef.FetchComponentSOAP(Session["Graphics_build"].ToString());
                selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                selectedComp += "<div class='col-md-12 col-xs-12'>";
                selectedComp += "<h5>" + graphics.category + "</h5>";
                selectedComp += "<p>" + graphics.name + "</p>";
                if (case2verify != null)
                {
                    if (case2verify.graphicsType == graphics.compatibility)
                    {
                        selectedComp += "<h6 style='color:green'>Compatible</h6>";
                    }
                    else
                    {
                        selectedComp += "<h6 style='color:orangered'>Not Compatible</h6>";
                    }
                }
               
                selectedComp += "<a href = '#'>R" + graphics.price + "</a>";
                selectedComp += "</div>";
                selectedComp += "<figure>";
                selectedComp += "<img alt='Professional Instructor'style='width:173px; height:93px' src='Content/images/products/components/" + graphics.image + "'>";
                selectedComp += "</figure>";
                selectedComp += "</div>";
                total += (int)graphics.intPriceFormat;
    
            }

            
            if (verifyNullSessionsForCompatibility()==false)
            {
                var status = SRef.VerifyBuildCompatibilitySOAP(Session["Desktop_build"].ToString(), Session["Ram_build"].ToString(),
                                  Session["CPU_build"].ToString(), Session["Storage_build"].ToString(), Session["Graphics_build"].ToString());  
                if (status != null)
                {
                    Session["compatibilityStatus"] = status.BuildCompatibility;
                    if (status.BuildCompatibility == "Compatible")
                    {
                        selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                        selectedComp += "<div class='col-md-12 col-xs-12'>";
                        selectedComp += "<h5>Build details:</h5>";
                        selectedComp += "<p>This build is compitable with all selected components. No issues detected</p>";
                        selectedComp += "<h6 style='color:green'>Ready to build</h6>";
                        selectedComp += "<a href = '#'>Total: R" + total + "</a>";
                        selectedComp += "</div>";
                        selectedComp += "<figure>";
                        selectedComp += "<div class='icon'><i class='fa fa-laptop'></i></div>";
                        selectedComp += "</figure>";
                        selectedComp += "</div>";
                    }
                    else
                    {
                        selectedComp += "<div class='overview_info instructor col-lg-2 col-md-3 col-sm-6 col-xs-12'>";
                        selectedComp += "<div class='col-md-12 col-xs-12'>";
                        selectedComp += "<h5>Build details:</h5>";
                        selectedComp += "<p>This build contains one or more components that is not compatible with your case.</p>";
                        selectedComp += "<h6 style='color:orangered'>Compatibility issues</h6>";
                        selectedComp += "<a href = '#'>Total: R" + total + "</a>";
                        selectedComp += "</div>";
                        selectedComp += "<figure>";
                        selectedComp += "<div class='icon'><i class='fa fa-laptop'></i></div>";
                        selectedComp += "</figure>";
                        selectedComp += "</div>";
                    }
                  

                }

            }
          
            shBuild.InnerHtml = selectedComp;
            
        }


        protected void btnBuildComputer_Click(object sender, EventArgs e)
        {

            if (verifyNullSessions() == false)
            {
                if (verifyNullSessionsForCompatibility() == false)
                {
                    string ram = Session["Ram_build"].ToString();
                    string cpu = Session["CPU_build"].ToString();
                    string storage = Session["Storage_build"].ToString();
                    string desktop = Session["Desktop_build"].ToString();
                    string user = Session["LoggedUser"].ToString();
                    string graphics = Session["Graphics_build"].ToString();
                    string totPrice = Convert.ToString(total);



                    int response = SRef.CreateBuildSOAP(user, desktop, cpu, storage, graphics, ram, Session["compatibilityStatus"].ToString(), totPrice);
                    if (response != -1)
                    {
                        Session.Remove("Ram_build");
                        Session.Remove("CPU_build");
                        Session.Remove("Storage_build");
                        Session.Remove("Graphics_build");
                        Session.Remove("Desktop_build");
                        Session.Remove("compatibilityStatus");
                        Session["ActiveBuild"] = response;
                        Response.Redirect("Cart.aspx");
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your build has compatibility issues, one or more component is not compatible with your case.')", true);

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


        public bool verifyNullSessionsForCompatibility()
        {
           
          
            if (Session["Desktop_build"] == null)
            {
                return true;
            }
            else if (Session["CPU_build"] == null)
            {
                return true;
            }
            else if (Session["Storage_build"] == null)
            {
                return true;
            }
            else if (Session["Graphics_build"] == null)
            {
                return true;
            }
            else if (Session["LoggedUser"] == null)
            {
                return true;
            }


           

            return false;
        }

     
    }
}