using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Añadido
using UnityEngine.UI;
using System.IO;
using System;


/*Scrip asociado a e GameObject Menu, para recoger y guardar los datos de un usuario en un fichero, y mostrar estos
 en el ScrollView srcViewListado*/
public class gestionDatos : MonoBehaviour
{

    public InputField txtInUsuario;
    public InputField txtInEmail;
    public InputField txtInPuntuacion;
    public Slider sldPuntuacion;

    public Button btnGuardar;
    public Button btnVaciar;
    public Button btnSalir;

    string ruta = "C:\\Users\\pinid\\Documents";
    string nombreFichero = "registros.txt";

    public Text txtRegistros;
    public Text txtMensajeErr;
    public Text txtRuta;
  
    // Use this for initialization
    void Start()
    {
        ruta = Application.persistentDataPath;
        ruta += "/" + nombreFichero;
        txtRuta.text = "Guardado en:\n" + ruta;
        Debug.Log(txtRuta.text);
        txtInPuntuacion.enabled = false;
        LeerRegistro();
    }

    // Update is called once per frame
    void Update()
    {
        VistaDePuntos();
    }

    /*Este metodo muestra el valor de puntos del Slider en el control Text txInPuntos*/
    private void VistaDePuntos()
    {
        if (sldPuntuacion.value >= 0)
            txtInPuntuacion.text = sldPuntuacion.value.ToString();
    }

    /*Este metodo guarda un registro en un fichero llamado Registro.txt*/
    public void GuardarRegistro()
    {
        if (txtInEmail.text != string.Empty && txtInUsuario.text != string.Empty)
        {
            MensajesError(String.Empty);//Limpiamos mensajes al usuario
            //Mientras guarda los botones quedan desacativados
            btnSalir.enabled = false;
            btnVaciar.enabled = false;
            btnGuardar.enabled = false;
            try
            {
                Debug.Log("EScribiendo1..");
                StreamWriter escritor = new StreamWriter(ruta, true, System.Text.Encoding.UTF8);
                try
                {
                    escritor.WriteLine("email:" + txtInEmail.text + " Usuario:" + txtInUsuario.text + " Puntos:" + txtInPuntuacion.text);
                }
                catch (Exception e)
                {
                    Debug.Log("ERROR al escribir el registro en el fichero: " + e.Message);
                }
                finally
                {
                    btnGuardar.enabled = true;//Activamos el boton al guardar
                    escritor.Close();
                }

                Reinicio();
                /*despues de guardar un registro, leeomos de nuevo el fichero
                 * para actualizar la el scrollView de Registros*/
                Debug.Log("Leiendo desde el escritro");
                LeerRegistro();

            }
            catch (Exception e)
            {
                Debug.Log("ERROR al delcarar el flujo de entrada: " + e.Message);

            }
            finally
            {
                btnGuardar.enabled = true;//Activamos el boton al guardar
                btnSalir.enabled = true;
                btnVaciar.enabled = true;

            }
        }
        else
            MensajesError("ERROR: Email y Usuario no pueden ser vacios.");
    }

    private void LeerRegistro()
    {
        try
        {
            //Vaciamos el ScrollView para no acumular viejos registros
            txtRegistros.text = string.Empty;
           
            if (File.Exists(ruta))//Si eziste el fichero
            {
                StreamReader lector = new StreamReader(ruta, System.Text.Encoding.UTF8);
                try
                {
                    while (!lector.EndOfStream)//mientras no este al final del fichero
                    {
                        string linea = lector.ReadLine();
                        txtRegistros.text += "\n" + linea;
                    }
                }
                catch(Exception e){
                    Debug.Log("ERROR al leer el fichero: " + e.Message);
                }
                finally
                {
                    if ( lector!= null)
                        lector.Close();
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log("ERROR al declarar el flujo de lectura: " + e.Message);
        }
       

    }

    public void BorrarRegistros()
    {
        try
        {
            btnVaciar.enabled = false;//Mientras Vacia el bootn queda desacativado
            if (File.Exists(ruta))
                File.Delete(ruta);

            Reinicio();
            LeerRegistro();
        }
        catch (Exception e)
        {
            Debug.Log("ERROR al borrar el fichero: " + e.Message);
        }
        finally
        {
            btnVaciar.enabled = true;
        }

    }

    /*Reinicio de interfaz*/
    private void Reinicio()
    {
        txtInUsuario.text = string.Empty;
        txtInEmail.text = string.Empty;
        txtInPuntuacion.text = string.Empty;
        sldPuntuacion.value = 0;
    }

    /*Mensajes de errores al usuario cuando no rellena nombre y Email*/
    private void MensajesError(string mensaje) {
        txtMensajeErr.text = mensaje;
    }

    public void SalirDeAplicacion()
    {
        Application.Quit();
        Debug.Log("Sali!");
    }
}
