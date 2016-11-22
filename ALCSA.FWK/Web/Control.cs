using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ALCSA.FWK.Web
{
    public class Control
    {
        #region DropDownList

        public static void SeleccionarValor(DropDownList lista, int valor)
        {
            SeleccionarValor(lista, valor.ToString());
        }

        public static void SeleccionarValor(DropDownList lista, string valor)
        {
            if (lista == null || valor == null) return;
            if (lista.Items.Count.Equals(0)) return;
            ListItem objItem = lista.Items.FindByValue(valor);
            if (objItem != null)
            {
                lista.SelectedIndex = -1;
                objItem.Selected = true;
            }
        }

        public static string ExtraerValor(DropDownList lista)
        {
            if (lista.SelectedIndex < 0) return string.Empty;
            return lista.SelectedValue.Trim();
        }

        public static string ExtraerTexto(DropDownList lista)
        {
            if (lista.SelectedIndex < 0) return string.Empty;
            return lista.SelectedItem.Text.Trim();
        }

        public static int ExtraerValorComoEntero(DropDownList lista)
        {
            if (lista.SelectedIndex < 0) return 0;
            return Texto.ConvertirTextoEnEntero(lista.SelectedValue);
        }

        #endregion

        #region HiddenField

        public static void AsignarValor(HiddenField campoOculto, string valor)
        {
            campoOculto.Value = valor;
        }

        public static void AsignarValor(HiddenField campoOculto, int valor)
        {
            campoOculto.Value = valor.ToString();
        }

        public static void AsignarValor(HiddenField campoOculto, DateTime valor)
        {
            campoOculto.Value = string.Empty;
            if (valor.Year <= 1900) return;
            campoOculto.Value = valor.ToString("dd/MM/yyyy").Replace("-", "/");
        }

        public static string ExtraerValor(HiddenField campoOculto)
        {
            return campoOculto.Value;
        }

        public static int ExtraerValorComoEntero(HiddenField campoOculto)
        {
            return Texto.ConvertirTextoEnEntero(campoOculto.Value);
        }

        public static decimal ExtraerValorComoDecimal(HiddenField campoOculto)
        {
            return Texto.ConvertirTextoEnDecimal(campoOculto.Value.Trim());
        }

        #endregion

        #region TextBox

        public static void AsignarValor(TextBox cajaTexto, string valor)
        {
            cajaTexto.Text = valor;
        }

        public static void AsignarValor(TextBox cajaTexto, int valor)
        {
            cajaTexto.Text = valor.ToString("N0");
        }

        public static void AsignarValor(TextBox cajaTexto, float valor, int numeroDecimales)
        {
            AsignarValor(cajaTexto, Convert.ToDecimal(valor), numeroDecimales);
        }

        public static void AsignarValor(TextBox cajaTexto, decimal valor, int numeroDecimales)
        {
            if (numeroDecimales < 0) numeroDecimales = 0;
            if (numeroDecimales > 15) numeroDecimales = 15;
            cajaTexto.Text = valor.ToString(string.Format("N{0}", numeroDecimales));
        }

        public static void AsignarValor(TextBox cajaTexto, DateTime valor)
        {
            cajaTexto.Text = string.Empty;
            if (valor.Year <= 1900) return;
            cajaTexto.Text = valor.ToString("dd/MM/yyyy").Replace("-", "/");
        }

        public static string ExtraerValor(TextBox cajaTexto)
        {
            return cajaTexto.Text.Trim();
        }

        public static int ExtraerValorComoEntero(TextBox cajaTexto)
        {
            return Texto.ConvertirTextoEnEntero(cajaTexto.Text.Trim().Replace(".", string.Empty));
        }

        public static decimal ExtraerValorComoDecimal(TextBox cajaTexto)
        {
            return Texto.ConvertirTextoEnDecimal(cajaTexto.Text.Trim());
        }

        public static float ExtraerValorComoFloat(TextBox cajaTexto)
        {
            return Texto.ConvertirTextoEnFloat(cajaTexto.Text.Trim());
        }

        public static DateTime ExtraerValorComoDateTime(TextBox cajaTexto)
        {
            return ExtraerValorComoDateTime(cajaTexto, "dd/MM/yyyy");
        }

        public static DateTime ExtraerValorComoDateTime(TextBox cajaTexto, DateTime fechaMinima)
        {
            DateTime datFecha = ExtraerValorComoDateTime(cajaTexto, "dd/MM/yyyy");
            return datFecha < fechaMinima ? fechaMinima : datFecha;
        }

        public static DateTime ExtraerValorComoDateTime(TextBox cajaTexto, string formato)
        {
            if(string.IsNullOrEmpty(formato)) formato = "dd/MM/yyyy";
            return Texto.ConvertirTextoEnDateTime(cajaTexto.Text.Trim(), formato);
        }

        public static DateTime ExtraerValorComoDateTime(HiddenField campoOculto)
        {
            return ExtraerValorComoDateTime(campoOculto, "dd/MM/yyyy");
        }

        public static DateTime ExtraerValorComoDateTime(HiddenField campoOculto, string formato)
        {
            if (string.IsNullOrEmpty(formato)) formato = "dd/MM/yyyy";
            return Texto.ConvertirTextoEnDateTime(campoOculto.Value.Trim(), formato);
        }

        #endregion

        #region Label

        public static void AsignarValor(Label etiqueta, string valor)
        {
            etiqueta.Text = valor;
        }

        public static void AsignarValor(Label etiqueta, int valor)
        {
            etiqueta.Text = valor.ToString("N0");
        }

        public static void AsignarValor(Label etiqueta, float valor, int numeroDecimales)
        {
            AsignarValor(etiqueta, Convert.ToDecimal(valor), numeroDecimales);
        }

        public static void AsignarValor(Label etiqueta, decimal valor, int numeroDecimales)
        {
            if (numeroDecimales < 0) numeroDecimales = 0;
            if (numeroDecimales > 15) numeroDecimales = 15;
            etiqueta.Text = valor.ToString(string.Format("N{0}", numeroDecimales));
        }

        public static void AsignarValor(Label etiqueta, DateTime valor)
        {
            AsignarValor(etiqueta, valor, false);
        }

        public static void AsignarValor(Label etiqueta, DateTime valor, bool palabras)
        {
            etiqueta.Text = string.Empty;
            if (valor.Year <= 1900) return;

            if (palabras)
                etiqueta.Text = string.Format("{0} de {1} de {2}", valor.Day, Tiempo.MESES[valor.Month - 1], valor.Year);
            else
                etiqueta.Text = valor.ToString("dd/MM/yyyy").Replace("-", "/");
        }

        public static int ExtraerValorComoEntero(Label etiqueta)
        {
            return Texto.ConvertirTextoEnEntero(etiqueta.Text);
        }

        #endregion
    }
}
