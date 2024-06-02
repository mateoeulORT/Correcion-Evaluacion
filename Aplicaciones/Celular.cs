class Celular
{
    public static List<App> ListaApps = new List<App>();

    private static double EspacioMB = 128000;

    public Celular(){}

    public bool InstalarApp(App app){
        
        bool sePudo = false;
        if (EspacioMB > 0)
        {
            ListaApps.Add(app);
            EspacioMB -= app.Peso;
            sePudo = true;
        } 
        return sePudo;
        
    }

    public bool ActualizarApp (string nombre){
        bool sePudo = false;

        foreach (App app in ListaApps)
        {
            if (app.Nombre == nombre)
            {
                app.Version++;
                Console.WriteLine(app.Version);
                sePudo = true;
            }
        }
        return sePudo;

    }

    public bool DesinstalarApp (string nombre){
        bool sePudo = false;
        int indice = 0;
        foreach (App app in ListaApps)
        {
            if (app.Nombre == nombre)
            {
                indice = ListaApps.IndexOf(app);
                EspacioMB += app.Peso;
                sePudo = true;
            }
        }

        if (indice != 0)
            ListaApps.RemoveAt(indice);

        return sePudo;

    }

    public void MostrarAppsInstaladas(){
        foreach (App app in ListaApps)
        {
            Console.WriteLine(app.Nombre);
        }
    }

    public void MostrarMemoriaDisponible(){

        Console.WriteLine(EspacioMB + "mb");
    }

    public void RestaurarDeFabrica(){
        ListaApps.Clear();
        EspacioMB = 128000;
    }








}