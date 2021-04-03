
namespace CompanyOrganogram
{
    public class EmployeeModel
    {
        public int Id { get; private set; }
        public int SuperiorId { get; private set; }
        public string Company { get; private set; }
        public string Name { get; private set; }
        public string Surename { get; private set; }
        public string City { get; private set; }
        public string Job { get; private set; }
        public string FirstNumber { get; private set; }
        public string SecondNumber { get; private set; }
        public string ThirdNumber { get; private set; }

        public EmployeeModel(int id, int superiorId, string name, string surename,
                        string company, string city, string job,
                        string firstNumber, string secondNumber, string thirdNumber)
        {
            Id = id;
            SuperiorId = superiorId;
            Name = name;
            Surename = surename;
            Company = company;
            City = city;
            Job = job;
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            ThirdNumber = thirdNumber;
        }
    }
}
