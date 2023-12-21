using System.Net;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using APICrudClient.Models;
using System.Text;

namespace APICrudclient
{
    
    public class APIGateway
    {
        
        private string url ="http://localhost:5246/api/Student";

        private HttpClient httpClient = new HttpClient();

        public List<Student> ListStudents()
        {
           List<Student> student = new List<Student>();
           if (url.Trim().Substring(0, 5).ToLower() == "https")
                     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                     

            try{
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result =response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Student>>(result);

                    if (datacol != null)
                      student =datacol;

                }

                else 
                 {
                        string result =response.Content.ReadAsStringAsync().Result;
                         throw new Exception("Error Occured at the API Endpoint,Error Info." + result);
                }
            }

                catch (Exception ex)
                {
                    throw new Exception("Error Occured at the API Endpoint,Error Info." + ex.Message);
                }

                finally{}
                return student;
                 
        }

        public Student CreateCustomer(Student student)
        {
          
           if (url.Trim().Substring(0, 5).ToLower() == "https")
                     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(student);    

            try{
                HttpResponseMessage response = httpClient.PostAsync(url,new StringContent(json,Encoding.UTF8,"application/json")).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result =response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Student>(result);

                    if (data != null)
                        student = data;

                }

                else 
                 {
                        string result =response.Content.ReadAsStringAsync().Result;
                         throw new Exception("Error Occured at the API Endpoint,Error Info." + result);
                }
            }

                catch (Exception ex)
                {
                    throw new Exception("Error Occured at the API Endpoint,Error Info." + ex.Message);
                }

                finally{}
                return student;
                 
        }


    
    public Student GetCustomer(int id)
        {
          Student student =new Student();
          url = url + "/" + id;
           if (url.Trim().Substring(0, 5).ToLower() == "https")
                     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(student);    

            try{
                 HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result =response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Student>(result);

                    if (data != null)
                        student = data;

                }

                else 
                 {
                        string result =response.Content.ReadAsStringAsync().Result;
                         throw new Exception("Error Occured at the API Endpoint,Error Info." + result);
                }
            }

                catch (Exception ex)
                {
                    throw new Exception("Error Occured at the API Endpoint,Error Info." + ex.Message);
                }

                finally{}
                return student;
                 
        }


         public Student UpdateCustomer(Student student)
        {
          
           if (url.Trim().Substring(0, 5).ToLower() == "https")
                     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int id = student.Id; 
            url = url + "/" + id;

            string json = JsonConvert.SerializeObject(student);   

            try{
                HttpResponseMessage response = httpClient.PutAsync(url,new StringContent(json,Encoding.UTF8,"application/json")).Result;
                if(response.IsSuccessStatusCode)
                {
                    string result =response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Student>(result);

                    if (data != null)
                        student = data;

                }

                else 
                 {
                        string result =response.Content.ReadAsStringAsync().Result;
                         throw new Exception("Error Occured at the API Endpoint,Error Info." + result);
                }
            }

                catch (Exception ex)
                {
                    throw new Exception("Error Occured at the API Endpoint,Error Info." + ex.Message);
                }

                finally{}
                return student;
                 
        }

  
  public void DeleteCustomer(int id)
        {
          
           if (url.Trim().Substring(0, 5).ToLower() == "https")
                     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
              url = url + "/" + id;
            

            try{
                 HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if(!response.IsSuccessStatusCode)
                {
                    
                     string result =response.Content.ReadAsStringAsync().Result;
                         throw new Exception("Error Occured at the API Endpoint,Error Info." + result);

                }

                
            }

                catch (Exception ex)
                {
                    throw new Exception("Error Occured at the API Endpoint,Error Info." + ex.Message);
                }

                finally  {  }

                return;
                 
        }


     


    }
}