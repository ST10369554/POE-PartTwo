namespace demo
{
    public class E_Cook_Recipe
    {
        //generics declaration
        private List<string> name = new List<string>();
        private List<string> quantity = new List<string>();
        private List<string> measurement = new List<string>();
        private List<string> food_group = new List<string>();


        //method to save recipe details
        public string saves(string names , string quantitys , string measurements , string food_groups)
        {
            //add values to the generics
            name.Add(names);
            quantity.Add(quantitys);
            measurement.Add(measurements);
            food_group.Add(food_groups);

            //return
            return "Capture is done !!";
        
        }

        //method to display all the values added
        public string displays()
        {
            //temp variable
            string message = "";
            //for loop 
            for (int count =0; count < name.Count;count++ )
            {

                message += "Recipe name: " + name[count] + "\n"
                    + "Recipe quantity : " + quantity[count] + "\n"
                    + "Recipe measurement : " + measurement[count]+"\n"
                    + "Recipe Food group : " + food_group[count] + "\n";
            }

            //return message
            return message;


        }


    }
}