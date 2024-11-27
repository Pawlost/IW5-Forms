using Duende.IdentityServer.Test;

namespace FormsIW5.IdentityProvider.App
{
    public class TestUsers
    {
        public static List<TestUser> Users { 
            get {
                var address = new {
                    street_address = "Hack"
                };
                return [
                    new TestUser{
                        SubjectId = "1",
                        Username="User",
                        Password="password",
                        Claims={ 
                        
                        }
                    }
                   ];
            }
        }
    }
}
