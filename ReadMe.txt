1. debe tener instalado visual studio 2015 ya que la aplicaci�n tiene complementos como crystal report.

2. debe tener un gestor en base de datos, puede ser MySql o Heidi Sql para guardar la infomrci�n 
proveniente de la aplicaci�n.

3. debe instalar Crystal report para la generaci�n de reportes no debe tener una version superior de visual studio 
anteriormente dicha por que no funciona. 

4. en el cd va estar el proyecto, la base de datos de la aplicaci�n, manual de usuario y este archivo.

5. una vez instalados estos programas, abra visual studio, dirigase a la opci�n Archivo en Abrir y busque la ruta del CD, abra la aplicaci�n del proyecto va tener el nombre babershop.

6. debe ir al explorar de soluciones de la aplicaci�n y buscar el web config o una carpeta Conexion y a la clase BdComun y verifique la cadena de conexi�n tal cual como esta. <addname="conexion_mysql"connectionString="Server=localhost;Database=babershop;user=root;password=root;port=3306"/>

7. abra el gestor de base de datos o directamente al archivo de base de datos el cual le pedira un usuario y contrase�a en
nuestro caso el usuario=root y contrase�a= root para ejecutar el script que va en el CD . 

8. una vez ejecutado la aplicaci�n puede utilizar el manual de usuario para entender el funcionamiento de la aplicaci�n web,dependiendo del rol habra un usuario y contrase�a, en el caso administrador el login es user= jaflors2010@hotmail.com y la 
contrase�a= 1234.




 protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            EventoController evc = new EventoController();
            List<Models.Evento> eve = evc.Calendario();
            for (int i = 0; i < eve.Count; i++)
            {
                if (e.Day.Date == eve[i].fecha)
                {
                    Label labelito = new Label();
                    labelito.Text = "<br>" + eve[i].p_nombre;
                    e.Cell.Controls.Add(labelito);
                }
            }

        }