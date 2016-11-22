﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MntClientes.aspx.cs" Inherits="CobranzaALC.Cobranza.mantenedores.MntClientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ALC Asesorìa Legal y Crediticía Ltda</title>
   
<link href="../../css/alc2.css" rel="stylesheet" type="text/css" />
<script src="../../js/funciones.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">



    function ValidarEliminar() {

        if (confirm('Esta seguro de eliminar el cliente ?')) {

            return true;

        } else return false;
    }


    function ValidarActualizar() {


        if (document.all("RadioButton1").checked == true) {
            if (trim(document.all("txtRazonSocial").value) == "") {
                alert('Debe ingresar la Razón Social');
                document.all("txtRazonSocial").focus();
                return false;
            }
        }


        if (document.all("RadioButton2").checked == true) {

            if (trim(document.all("txtNombres").value) == "") {
                alert('Debe ingresar los nombres');
                document.all("txtNombres").focus();
                return false;
            }
            if (trim(document.all("txtAPaterno").value) == "") {
                alert('Debe ingresar el apellido paterno');
                document.all("txtAPaterno").focus();
                return false;
            }

            if (trim(document.all("txtAMaterno").value) == "") {
                alert('Debe ingresar el apellido materno');
                document.all("txtAMaterno").focus();
                return false;
            }
        }



        if (!(document.all("txtRutRepLegal").value == "")) {

            if (!(ChequeaRut(document.all("txtRutRepLegal")))) {
                alert('Rut no es válido');
                document.all("txtRutRepLegal").focus();
                document.all("txtRutRepLegal").select();
                return false;
            }
        }

        if (confirm('Esta seguro de actualizar el cliente ?')) {
            return true;

        } else return false;
    }

    function ValidarGuardar() {

        if (document.all("RadioButton1").checked == true) {
            if (trim(document.all("txtRazonSocial").value) == "") {
                alert('Debe ingresar la Razón Social');
                document.all("txtRazonSocial").focus();
                return false;
            }
        }


        if (document.all("RadioButton2").checked == true) {

            if (trim(document.all("txtNombres").value) == "") {
                alert('Debe ingresar los nombres');
                document.all("txtNombres").focus();
                return false;
            }
            if (trim(document.all("txtAPaterno").value) == "") {
                alert('Debe ingresar el apellido paterno');
                document.all("txtAPaterno").focus();
                return false;
            }

            if (trim(document.all("txtAMaterno").value) == "") {
                alert('Debe ingresar el apellido materno');
                document.all("txtAMaterno").focus();
                return false;
            }
        }


        if (!(document.all("txtRutRepLegal").value == "")) {

            if (!(ChequeaRut(document.all("txtRutRepLegal")))) {
                alert('Rut no es válido');
                document.all("txtRutRepLegal").focus();
                document.all("txtRutRepLegal").select();
                return false;
            }
        }



        if (confirm('Esta seguro de guardar el cliente ?')) {

            return true;

        } else return false;
    }


    function ValidarBuscar() {

        if (!(ChequeaRut(document.all("txtRut")))) {
            alert('Rut no es válido');
            document.all("txtRut").focus();
            document.all("txtRut").select();

            return false;
        }

        if (document.all("txtRut").value == "") {
            alert('Debe ingresar el Rut');
            document.all("txtRut").focus();
            return false;
        }

        return true;

    }

 </script>
 
    <style type="text/css">
        .style1
        {
            width: 213px;
        }
        .style2
        {
            FONT-WEIGHT: normal;
            FONT-SIZE: 12px;
            COLOR: #493f46;
            FONT-FAMILY: "Gill Sans MT", Arial;
            width: 103px;
        }
        .style3
        {
            FONT-WEIGHT: normal;
            FONT-SIZE: 12px;
            COLOR: #493f46;
            FONT-FAMILY: "Gill Sans MT", Arial;
            width: 84px;
        }
        .style4
        {
            width: 42px;
        }
    </style>
 
</head>
<body  >


 <TABLE cellSpacing="0" cellPadding="0" border="0" style="width: 669px">
  <TBODY> 
  <TR> 
    <TD width="633" height=50 valign="top" bgcolor="#336699" xbackground="../../images/banner2.jpg"> 
      <TABLE width=313 align=right border=0>
        <TBODY> 
        <TR> 
          <TD class=titulo align=right>SISTEMA DE COBRANZA</TD>
        </TR>
        </TBODY> 
      </TABLE>
    </TD>
  </TR>
  <TR> 
    <TD height="394" valign="top" class=textos><BR>
      <CENTER>
      </CENTER>
      
      <FORM runat="server" id="Formulario"   >
      
        <TABLE align=center border=0 style="width: 682px"  >
          <TBODY> 
          <TR> 
            <TD height="247" width="100%" valign="top"> 
            
            <!-- Zona de Titulo -->
            
              <TABLE borderColor=#c8e3f9 cellSpacing=0 cellPadding=0 
                        width=100% border=1>
                <TBODY> 
                <TR> 
                  <TD align="left"  bgColor=#eeeeee><b>&nbsp;MANTENEDOR CLIENTES</b></TD>
                </TR>
                </TBODY> 
              </TABLE>
              <TABLE height=7 width=345>
                <TBODY> 
                <TR> 
                  <TD>
                     
                    </TD>
                </TR>
                </TBODY> 
              </TABLE>
              
              <!-- Tabla Cuerpo Inicio -->
              
              <table borderColor=#c8e3f9 cellSpacing=0 cellPadding=0 width=633 border=1 height="100" >
              <tr>
              <td valign="top">
               
                  <table border="0" bgColor=#e6ecf2 border=0 style="width: 681px">
                    <tr>
                     <td class="textos22"  colspan="4">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="style2" >Rut :</td>
                        <td  align="left" class="style1" >
                            <asp:TextBox ID="txtRut" runat="server" 
                                style="WIDTH: 120px; margin-left: 0px; "></asp:TextBox>
                                <font color="red" size="-2"><b> Ej. 12324654-6</b></font>
                            </td>
                        <td align="right" class="style3" ></td>
                        <td  align=left class="style4">
                          
                        </td>
                    </tr>
                    
                        <tr>
                         
                        <td align="right" class="style2" >Tipo Persona :</td>
                        <td  align="left" class="style4" style="WIDTH: 150px;" >
                          
                            <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true"  
                                GroupName="valor"  Text="Juridica" Checked="true" 
                                oncheckedchanged="RadioButton1_CheckedChanged" Enabled="False" />
                            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="true"  
                                GroupName="valor"  Text="Natural" 
                                oncheckedchanged="RadioButton2_CheckedChanged" Enabled="False"/>
                         
                        </td>
                       </tr>
                    
                    
                    <!-- Persona Juridica -->
                    <asp:Panel ID="PanelRazon" runat="server">
                    <tr>
                        <td align="right" class="style2" >Razón Social:</td>
                        <td  align="left" class="style1" colspan="3" >
                            <asp:TextBox ID="txtRazonSocial" runat="server"  MaxLength="40"
                                style="WIDTH: 230px; margin-left: 0px; "></asp:TextBox>
                        </td>
                       
                    </tr>
                    </asp:Panel>
                    <!-- Fin Persona Juridica -->
                    
                    
                    
                    <!-- Persona Natural -->
                   <asp:Panel ID="PanelPnatural" runat="server" Visible="false"> 
                     <tr>
                        <td align="right" class="style2" >Nombres :</td>
                        <td  align="left" class="style1"  colspan="3">
                          <asp:TextBox ID="txtNombres" runat="server" ReadOnly="True" MaxLength="35"
                                style="WIDTH: 250px; margin-left: 0px; "></asp:TextBox>
                         </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="style2" >A. Paterno :</td>
                        <td  align="left" class="style1" >
                            <asp:TextBox ID="txtAPaterno" runat="server" MaxLength="30" 
                                style="WIDTH: 200px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right" class="style3" >A. Materno :</td>
                        <td  align=left class="style4">
                            <asp:TextBox ID="txtAMaterno" runat="server" MaxLength="30" ReadOnly="True" 
                                style="WIDTH: 200px; margin-left: 0px;" ></asp:TextBox>
                        </td>
                    </tr>
                    </asp:Panel>
                    <!-- Fin Persona Natural -->
                    
                    <tr>
                        <td align="right" class="style2" >Dirección :</td>
                        <td  align="left" class="style1" >
                            <asp:TextBox ID="txtDireccion" runat="server" 
                                style="WIDTH: 230px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right" class="style3" >Número :</td>
                        <td  align=left class="style4">
                            <asp:TextBox ID="txtNumero" runat="server" MaxLength="8" 
                                style="WIDTH: 100px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td align="right" class="style2" >Región :</td>
                        <td  align="left" class="style1" >
                          <asp:DropDownList ID="region" runat="server" Enabled="False" AutoPostBack="True" style="WIDTH: 180px; margin-left: 0px; "
                                onselectedindexchanged="region_SelectedIndexChanged">
                               
                            </asp:DropDownList>

                        </td>
                        <td align="right" class="style3" >Comuna :</td>
                        <td  align=left class="style4">
                         <asp:DropDownList ID="comuna" runat="server" Enabled="False" style="WIDTH: 180px; margin-left: 0px; ">
                                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="style2" >Teléfono :</td>
                        <td  align="left" class="style1" >
                           <asp:TextBox ID="txtTelefono" runat="server" 
                                style="WIDTH: 100px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td align="right" class="style3" >Fax :</td>
                        <td  align=left class="style4">
                            <asp:TextBox ID="txtFax" runat="server" style="WIDTH: 100px; margin-left: 0px;" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    
                      <tr>
                        <td align="right"  class="style2" >Mail :</td>
                        <td  align="left" class="style1" >
                           <asp:TextBox ID="txtMail" runat="server" style="WIDTH: 200px; margin-left: 0px;" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        
                       </tr>
                       
                        <tr>
                        <td align="right" class="style2" >Rut Rep. Legal :</td>
                        <td  align="left" class="style1" >
                            <asp:TextBox ID="txtRutRepLegal" runat="server" 
                                style="WIDTH: 110px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                                <font color="red" size="-2"><b> Ej. 12324654-6</b></font>
                        </td>
                        <td align="right" class="style3" >Rep. Legal :</td>
                        <td  align=left class="style4">
                            <asp:TextBox ID="txtRepLegal" runat="server" 
                                style="WIDTH: 190px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                     <td class="textos22"  colspan="4">&nbsp;</td>
                    </tr>
                    
                  </table>
 
              </td>
            </tr>
            
            
            </table>
            
                <!-- Tabla Cuerpo Fin -->
              
            </TD>
          </TR>
          <TR> 
            <TD  valign="top" bgcolor="#CCCCCC"> 
              
              <!-- Zona de Botoneras -->
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="600" height="35" > 
                    <div align="center"> 
                        <asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" 
                           OnClientClick="return ValidarBuscar();" onclick="btnBuscar_Click" />
                            
                       <asp:Button ID="btnGuardar" runat="server" CssClass="boton" Text="Guardar" 
                            OnClientClick="return ValidarGuardar();" onclick="btnGuardar_Click" Visible="False" />
                   
                       <asp:Button ID="btnActualizar" runat="server" CssClass="boton" Text="Actualizar" 
                            OnClientClick="return ValidarActualizar();" Visible="False" onclick="btnActualizar_Click" />
                   
                       <asp:Button ID="btnEliminar" runat="server" CssClass="boton" Text="Eliminar" Visible="False"
                             OnClientClick="return ValidarEliminar();" onclick="btnEliminar_Click" />
                   
                       <asp:Button ID="btnCancelar" runat="server" CssClass="boton" Text="Cancelar" 
                            onclick="btnCancelar_Click"  Visible="False" />
                       
                     </div>
                  </td>
                </tr>
              </table>
              
            </TD>
          </TR>
          </TBODY> 
        </TABLE>
        <div align="center"><font size="2">Estado Nº 359 Piso 13, Santiago - Chile | Teléfonos : 633 3115 - 633 3483 
          </font> </div>
         
          <asp:HiddenField ID="CodCliente"  runat="server" />
          
      </FORM>
      
    </TD>
  </TR>
  </TBODY> 
</TABLE>

</body>
</html>
