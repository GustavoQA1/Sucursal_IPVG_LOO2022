namespace API
{
    public record AdministradorDTO(string rut, string nombre, string apellido, string email);
    public record SucursalDTO(int id, string nombre, string direccion, string telefono, string rut);
    public record DepartamentoDTO(int id, string nombre, int id_sucursal);
}
