namespace AnimalBalanceApp.Api.Responses
{
    public class ApiResponse<T>
    {
        //Respuesta generica del api que le setea la respuesta en la propiedad data
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
