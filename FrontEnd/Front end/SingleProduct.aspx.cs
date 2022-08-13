﻿using Front_end.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front_end
{
    public partial class tryUser : System.Web.UI.Page
    {
        ServiceClient SRef = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            string dispComp = "";
            string dispD = "";
            string dispRec = "";
            string product_id = "";
            if (Request.QueryString["pId"] != null)
            {
               product_id = Request.QueryString["pId"].ToString();
                var component = SRef.FetchComponentSOAP(product_id);
                dynamic recommended = SRef.FetchTopComponentsSOAP(component.category,"4");
                if (component != null)
                {
                dispD = component.description;
                    dispComp += "<div class='col-md-5 col-xs-12 text-center'>";
                    dispComp += "<img alt='Leonardo Bonucci' src='Content/images/products/components/"+component.image+"'>";
                    dispComp += "</div>";
                    dispComp += "<div class='teacher_info col-md-7 col-xs-12'>";
                    dispComp += "<h4>"+component.name+"<em>R"+component.price+"</em></h4>";
                    dispComp += "<div class='teach_sumarry'>";
                    dispComp += "<h5>Description:</h5>";
                    dispComp += "<p>"+component.description+"</p>";
                    dispComp += "</div>";
                    dispComp += "<div class='course_tags'>";
                dispComp += "<ul>";
                dispComp += "<li>";
                     dispComp += "<a href='Cart.aspx?pId="+component.Id+"'>Add to cart</a>";
                     dispComp += "<a href='BuildComputer.aspx?"+component.category+"_build="+component.Id+"'>Add to build</a>";
                dispComp += "<a href='#'>Add to wishlist </a>";
                dispComp += "</li>";
                dispComp += "</ul>";
                dispComp += "</div>";

                    dispComp += "</div>";
            }

                if (recommended != null)
                {
                    
                        foreach (Component rec in recommended)
                    {

                        //displaying 5 recommended items
                        dispRec += "<li>";
                     dispRec +="<div class='tutor_img'>";
                        dispRec += "<img alt='Alaxander Louise' src='Content/images/products/components/"+rec.image+"'>";
                     dispRec += "</div>";
                       dispRec += "<div class='tutor_info'>";
                       dispRec += "<h5>";
                       dispRec += "<a href='SingleProduct.aspx?pid="+rec.Id+"'>"+rec.name+"</a>";
                        dispRec += "<em>R"+rec.price+"</em>";
                        dispRec += "</h5>";
                        dispRec += "</div>";
                        dispRec += "</li>"; 

                    }
                    recList.InnerHtml = dispRec;
                }




            }


            dispProduct.InnerHtml=dispComp;
            dispDescr.InnerText = dispD;



        }

       
    }
    
}