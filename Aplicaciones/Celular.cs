class Celular
{
    public static List<App> ListaApps = new List<App>();

    private static double EspacioMB = 128000;

    public Celular(){}

    public bool InstalarApp(App app){
        
        bool sePudo = false;
        if (EspacioMB - app.Peso >= 0)
        {
            ListaApps.Add(app);
            EspacioMB -= app.Peso;
            sePudo = true;
        } 
        return sePudo;
        
    }

    public bool ActualizarApp (string nombre){
        bool sePudo = false;
        int indice = BuscarAppEnListaApps(nombre);
        if (indice != -1)
        {
            sePudo = true;
            ListaApps[indice].Version++;
            Console.WriteLine(ListaApps[indice].Version);     
        }
        return sePudo;

    }

    public bool DesinstalarApp (string nombre){
        bool sePudo = false;
        int indice = BuscarAppEnListaApps(nombre);

        if (indice != -1){
            EspacioMB += ListaApps[indice].Peso;
            sePudo = true;
            ListaApps.RemoveAt(indice);
        }
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

    static int BuscarAppEnListaApps (string nombre){
        int indice = 0;

        while (indice < ListaApps.Count)
        {
            if (ListaApps[indice].Nombre == nombre)
            {
                return indice;
            }
            indice++;
        }
        return -1;
    }






}