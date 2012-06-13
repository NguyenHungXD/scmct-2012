
	 	var requpdate; 
	 	function loadXMLUpdate(url) 
	    { 
	 		window.status="Getting data from server......."; 
	 		requpdate=null; 
	 		if (window.XMLHttpRequest && !(window.ActiveXObject) ) 
	        {// code for Firefox, Opera, IE7, etc. 
	     	    try
                { 
	 			    requpdate = new XMLHttpRequest(); 
	            } 
                catch(e) 
                { 
	 			                requpdate = false; 
	            }       
	        } 
	 		 else if (window.ActiveXObject) 
	        {// code for IE6, IE5 
	       	    try
                { 
	   			    requpdate = new ActiveXObject("Msxml2.XMLHTTP"); 
	            }
                catch(e)
                { 
	        	    try
                    { 
	          		    requpdate = new ActiveXObject("Microsoft.XMLHTTP"); 
	         	    }
                    catch(e) { 
	           		    requpdate = false; 
	        	    } 
	 		    } 
	        } 

	 		if (requpdate!=null) 
	        { 
	   			requpdate.onreadystatechange=function(){processReqUpdate();} 
	   			requpdate.open("POST",url,true); 
	  			requpdate.send(null); 	
	 		        window.status="Done"; 
	        } 
	 		else
	   		    alert("Your browser does not support XMLHTTP."); 
	   }
	
	 function processReqUpdate() { 
     try
                { 
	     // only if requpdate shows "loaded" 
	     if (requpdate.readyState == 4)
         { 
	     // only if "OK" 
             if (requpdate.status == 200) { 

	         // ...processing statements go here... 
	 		        eval(requpdate.responseText); 		
	 		        window.status="Done"; 
	         }
             else
             { 
	           //alert("There was a problem retrieving the XML data:\n" + requpdate.statusText); 
	          } 
	     } 
         }
catch (e) {
    return;
} 
	 } 	
    
	 	var req; 
	 	var v_div; 
	 function AssignDataToDIV(url,vdiv) 
	 { 
	 	v_div = vdiv; 
	 		window.status="Getting data from server......."; 
	 		req=null; 
	 		if (window.XMLHttpRequest && !(window.ActiveXObject) ) 
	        {// code for Firefox, Opera, IE7, etc. 
	     	try
                { 
	 			    req = new XMLHttpRequest(); 
	            }
             catch(e)
                    { 
	 			        req = false; 
	                } 
	        } 
	 		else if (window.ActiveXObject) 
	        {// code for IE6, IE5 
	       	    try { 
	   			    req = new ActiveXObject("Msxml2.XMLHTTP"); 
	             } catch(e) { 
	        	    try { 
	          		    req = new ActiveXObject("Microsoft.XMLHTTP"); 
	         	    } catch(e) { 
	           		    req = false; 
	        	    } 
	 		} 
	   } 
	 		if (req!=null) 
	   { 
	   			req.onreadystatechange=function(){processReqChange();} 
	
	   			req.open("POST",url,true); 
	  			req.send(null); 	
	 		        window.status="Done"; 
	   } 
	 		else
	   { 
	   		alert("Your browser does not support XMLHTTP."); 
	   } 
	 } 	
	
	 function processReqChange() { 
	 // only if req shows "loaded" 
	
	 if (req.readyState == 4) { 
	 // only if "OK" 
	 if (req.status == 200) { 
	 // ...processing statements go here... 
	 		displayMessages(req.responseText); 		
	 		window.status="Done"; 
	 } else { 
	   //alert("There was a problem retrieving the XML data:\n" + displayErrors(req.statusText)); 
	
	  } 
	 } 
	 } 	
	
	 // function that displays an error message 
	 function displayErrors(message) 
	 { 
  	 // display error message, with more technical details if debugMode is true 
  	      displayMessages("Error accessing the server! ",v_div); 
  	 } 
  	
  	 // displays a message 
	 function displayMessages(v_message) 
	 { 
	 	var assigndiv = document.getElementById(v_div); 
	 	assigndiv.innerHTML = v_message; 
	 } 

	
	 function getValXML(url) 
	 { 
	 var http = false; 
	 if (window.XMLHttpRequest && !(window.ActiveXObject) ) 
	   {// code for Firefox, Opera, IE7, etc. 
	     	try { 
	 		http = new XMLHttpRequest(); 
	         } catch(e) { 
	 			http = false; 
	        } 
	   } 
	 		else if (window.ActiveXObject) 
	   {// code for IE6, IE5 
	       	try { 
	   			http = new ActiveXObject("Msxml2.XMLHTTP"); 
	         } catch(e) { 
	        	try { 
	          		http = new ActiveXObject("Microsoft.XMLHTTP"); 
	         	} catch(e) { 
	           		http = false; 
	        	} 
	 		} 
	   } 
	   http.open("POST", url, false);  
	   http.send(null); 
	   var result = http.responseText; 
	   return result.substring(0,result.length);  
	 } 
	

function readXMLFormat(content,tagNameStart,tagNameEnd)
{
    var startIndex = content.indexOf(tagNameStart) + tagNameStart.length ;
    var endIndex =  content.indexOf(tagNameEnd);
    if(endIndex>0) 
        return content.substring(startIndex,endIndex);
    else
        return "";
}







 
