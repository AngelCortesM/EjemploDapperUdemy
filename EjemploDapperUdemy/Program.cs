
using Dapper;
using EjemploDapperUdemy;
using System.Data;
using System.Data.SqlClient;

string connectionString = "Data Source=DEV14;Initial Catalog=CursoWebAPINet;User Id=angelC;Password=Angelica357@;";

using (SqlConnection sql = new SqlConnection(connectionString))
{

    //P.A  Alta Nuevo
    Prueba p = new Prueba();
    p.Nombre = "XXXXXXXXXX";
    var param = new DynamicParameters();
    param.Add("@Nombre", p.Nombre);
    sql.ExecuteScalar("EjemploInsert", param, commandType: CommandType.StoredProcedure);

    //P.A SIN PARAMETROS
    var r = sql.ExecuteReader("Ejemplo", commandType: CommandType.StoredProcedure);
    while (r.Read())
        Console.WriteLine(r["Nombre"]);
    r.Close();

    Console.WriteLine("--------------------------------------------------------------------");

    var parametro = new DynamicParameters();
    parametro.Add("@id", 1);
    r = sql.ExecuteReader("Ejemplo", parametro, commandType: CommandType.StoredProcedure);
    while (r.Read())
        Console.WriteLine(r["Nombre"]);
    r.Close();


    /* //INSERTAR
    Prueba prueba = new Prueba();
    prueba.Nombre = "Ignacio";
    var insertar = "INSERT INTO dbo.prueba(Nombre) values (@Nombre) ";
    var resultado = sql.Execute(insertar, prueba);

    //ACTUALIZAR
    prueba.Nombre = "Francisco";
    var actualizar = "UPDATE dbo.Prueba SET Nombre = @Nombre Where Id='6' ";
    resultado = sql.Execute(actualizar, prueba);

    //BORRAR
    prueba.Nombre = "Ignacio";
    var borrar = "DELETE FROM dbo.Prueba WHERE nombre = @Nombre ";
    resultado = sql.Execute(borrar, prueba);

    //LISTADO
    var consulta = "Select * from prueba";
    var lista = sql.Query<Prueba>(consulta);
    foreach (var item in lista)
    {
        Console.WriteLine(item.Id + "                              " + item.Nombre);
    }
    Console.WriteLine("Pulsa Enter para continuar");
    Console.ReadLine();*/
}