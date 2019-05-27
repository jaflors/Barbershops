1. debe tener instalado visual studio 2015 ya que la aplicación tiene complementos como crystal report.

2. debe tener un gestor en base de datos, puede ser MySql o Heidi Sql para guardar la infomrción 
proveniente de la aplicación.

3. debe instalar Crystal report para la generación de reportes no debe tener una version superior de visual studio 
anteriormente dicha por que no funciona. 

4. en el cd va estar el proyecto, la base de datos de la aplicación, manual de usuario y este archivo.

5. una vez instalados estos programas, abra visual studio, dirigase a la opción Archivo en Abrir y busque la ruta del CD, abra la aplicación del proyecto va tener el nombre babershop.

6. debe ir al explorar de soluciones de la aplicación y buscar el web config o una carpeta Conexion y a la clase BdComun y verifique la cadena de conexión tal cual como esta. <addname="conexion_mysql"connectionString="Server=localhost;Database=babershop;user=root;password=root;port=3306"/>

7. abra el gestor de base de datos o directamente al archivo de base de datos el cual le pedira un usuario y contraseña en
nuestro caso el usuario=root y contraseña= root para ejecutar el script que va en el CD . 

8. una vez ejecutado la aplicación puede utilizar el manual de usuario para entender el funcionamiento de la aplicación web,dependiendo del rol habra un usuario y contraseña, en el caso administrador el login es user= jaflors2010@hotmail.com y la 
contraseña= 1234.




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