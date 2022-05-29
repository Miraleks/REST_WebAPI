namespace WebClient.Generators
{
    class CustomerGenerator
    {
        public static CustomerCreateRequest RandomCustomer()
        {
            var customer = new CustomerCreateRequest(firstName: Faker.NameFaker.FirstName(), lastName: Faker.NameFaker.LastName());

            return customer;
        }
    }
}
