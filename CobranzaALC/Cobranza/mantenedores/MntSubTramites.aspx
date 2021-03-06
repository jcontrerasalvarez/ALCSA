﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MntSubTramites.aspx.cs" Inherits="CobranzaALC.Cobranza.mantenedores.MntSubTramites" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ALC Asesorìa Legal y Crediticía Ltda</title>
   
<link href="../../css/alc2.css" rel="stylesheet" type="text/css" />
<script src="../../js/funciones.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">


    function ValidarEliminar() {

        if (confirm('Esta seguro de eliminar el domicilio ?')) {

            return true;

        } else return false;
    }


    function ValidarActualizar() {

        if (confirm('Esta seguro de actualizar el domicilio ?')) {

            if (document.all("txtRazonSocial").value == "") {
                alert('Debe ingresar la Razón Social');
                document.all("txtRazonSocial").focus();
                return false;
            }

            return true;

        } else return false;
    }

    function ValidarGuardar() {


        if (trim(document.all("Tipo").value) == "0") {
            alert('Debe ingresar tipo');
            document.all("Tipo").focus();
            return false;
        }

        if (trim(document.all("txtDescripcion").value) == "") {
            alert('Debe ingresar descripción');
            document.all("txtDescripcion").focus();
            return false;
        }




        if (confirm('Esta seguro de guardar el subtramite? recuerde que los tipos de subtramite no se pueden eliminar, ni editar.')) {
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
        .style5
        {
            FONT-WEIGHT: normal;
            FONT-SIZE: 12px;
            COLOR: #493f46;
            FONT-FAMILY: "Gill Sans MT", Arial;
            width: 268435216px;
        }
        </style>
 
</head>
<body  >


 <TABLE cellSpacing="0" cellPadding="0" width="633" border="0">
  <TBODY> 
  <TR> 
    <TD width="633" height=50 valign="top" bgcolor="#336699" xbackground="../../images/banner2.jpg"> 
      <TABLE align=right border=0 style="width: 358px">
        <TBODY> 
        <TR> 
          <TD class=titulo align=right>SISTEMA DE RECONSTITUCIONES</TD>
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
      
        <TABLE width=633 align=center border=0  >
          <TBODY> 
          <TR> 
            <TD height="184" width="100%" valign="top"> 
            
            <!-- Zona de Titulo -->
            
              <TABLE borderColor=#c8e3f9 cellSpacing=0 cellPadding=0 
                        width=100% border=1>
                <TBODY> 
                <TR> 
                  <TD align="left"  bgColor=#eeeeee><b>&nbsp;MANTENEDOR SUBTRAMITE</b></TD>
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
               
                  <table border="0" width="633" bgColor=#e6ecf2 border=0>
                    <tr>
                     <td class="style5"  colspan="4">&nbsp;</td>
                    </tr>
                
                
                        <tr>
                          <td align="right" class="style4" >Tipo:</td>
                        <td  align=left>
                         
                              <asp:DropDownList ID="Tipo" runat="server"  AutoPostBack=true
                                style="WIDTH: 200px; margin-left: 0px; " onselectedindexchanged="Tipo_SelectedIndexChanged"
                                >
                              <asp:ListItem Value="0">Seleccione</asp:ListItem>  
                              <asp:ListItem Value="DOCUJUICIO">DOCU JUICIO</asp:ListItem>
                              <asp:ListItem Value="DOCUPAGARE">DOCU PAGARE</asp:ListItem>
                              <asp:ListItem Value="MUTUO">MUTUO</asp:ListItem>
                              <asp:ListItem Value="ESTANDARD1">ESTANDARD 1-2-3-4</asp:ListItem>
                              
                           </asp:DropDownList>
                           
                        </td> 
                        
                           <td align="right" class="style3" ></td>
                        <td  align=left>
                         
                        </td>
                    </tr>
                
                    
           
                    
                  <tr>
                          <td align="right" class="style4" >Descripción&nbsp; :</td>
                        <td  align=left>
                            <asp:TextBox ID="txtDescripcion" runat="server" 
                                style="WIDTH: 350px; margin-left: 0px;"  Width="278px"></asp:TextBox>
                        </td> 
                        
                           <td align="right" class="style3" ><%--Block :--%></td>
                        <td  align=left>
                         <%--   <asp:TextBox ID="txtBlock" runat="server" 
                                style="WIDTH: 100px; margin-left: 0px;" ReadOnly="True"></asp:TextBox>--%>
                        </td>
                    </tr>
                    
                   
               <tr>
                          <td align="right" class="style4" >Termino:</td>
                        <td  align=left>
                         
                              <asp:DropDownList ID="termino" runat="server" 
                                style="WIDTH: 180px; margin-left: 0px; "
                                >
                            
                              <asp:ListItem Value="N">N (no)</asp:ListItem>
                              <asp:ListItem Value="S">S (si)</asp:ListItem>
                              
                           </asp:DropDownList>
                           
                        </td> 
                        
                           <td align="right" class="style3" ></td>
                        <td  align=left>
                         
                        </td>
                    </tr>
                    
                    
                    
                    
                    
            <tr>
                        <td align="right" class="style4" ></td>
                        <td  align="left" class="style1" >
                          

                        </td>
                        <td align="right" class="style3" ></td>
                        <td  align=left>
                         
                        </td>
                    </tr>
      <%--              
                    <tr>
                        <td align="right" class="style4" >Vigencia :</td>
                        <td  align="left" class="style1" >
                          <asp:DropDownList ID="vigencia" runat="server" 
                                 Enabled="False" onselectedindexchanged="vigencia_SelectedIndexChanged" style="WIDTH: 180px; margin-left: 0px; "
                                >
                              <asp:ListItem Value="1">Vigente</asp:ListItem>
                              <asp:ListItem Value="2">No Vigente</asp:ListItem>
                           </asp:DropDownList>
                        </td>
                        <td align="right" class="style3" >Fuente :</td>
                        <td  align=left>
                         <asp:DropDownList ID="fuente" runat="server" Enabled="False" style="WIDTH: 180px; margin-left: 0px; ">
                             <asp:ListItem Value="0">Seleccione</asp:ListItem>
                             <asp:ListItem Value="1">Cambio de Domicilio</asp:ListItem>
                             <asp:ListItem Value="2">No existe Domicilio</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                    
                    <tr>
                     <td class="style5"  colspan="4"><%--&nbsp;<b>NOTA :</b> Recuerde que <b> NO</b> se pueden agregar estados de inicio y término. Solo estados simples--%></td>
                    </tr>
                    
                     <tr>
                     <td class="style5"  colspan="4">&nbsp;</td>
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
                            OnClientClick="return ValidarGuardar();" onclick="btnGuardar_Click" 
                            Visible="False" />
                   
                       <asp:Button ID="btnCancelar" runat="server" CssClass="boton" Text="Cancelar"  Visible="False"
                            onclick="btnCancelar_Click" />
                       
                     </div>
                  </td>
                </tr>
              </table>
              
            </TD>
          </TR>
          </TBODY> 
        </TABLE>
        
        
                  <asp:GridView ID="grilla" runat="server" CellPadding="4" ForeColor="#333333"  Width="640"
                    
                     AutoGenerateColumns="False"
                      GridLines="None">
                 
                      <Columns>
                      <asp:TemplateField HeaderText="Descripción">
                                <HeaderStyle Wrap="true" HorizontalAlign=Left></HeaderStyle>
                                <ItemStyle Wrap="false" HorizontalAlign=Left ></ItemStyle>
                                <ItemTemplate>
                                <asp:Label ID="lblCoditrtgo21" runat="server" Text='<%# Bind("descripcion") %>' SortExpression = "Codigo" SortDirection="ASC"></asp:Label>
                              </ItemTemplate>
                             </asp:TemplateField>
                             
                             
                               
                      <asp:TemplateField HeaderText="Tipo">
                                <HeaderStyle Wrap="true"  HorizontalAlign=Left></HeaderStyle>
                                <ItemStyle Wrap="false" ></ItemStyle>
                                <ItemTemplate>
                                <asp:Label ID="lblCodigott31" runat="server" Text='<%#Evaluar(Eval("Tipo")) %>' SortExpression = "Codigo" SortDirection="ASC"></asp:Label>
                              </ItemTemplate>
                             </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Termino">
                                <HeaderStyle Wrap="true"  HorizontalAlign=Left></HeaderStyle>
                                <ItemStyle Wrap="false" ></ItemStyle>
                                <ItemTemplate>
                                <asp:Label ID="lblCodigorrr331" runat="server" Text='<%# Bind("termino") %>' SortExpression = "Codigo" SortDirection="ASC"></asp:Label>
                              </ItemTemplate>
                             </asp:TemplateField>
                           
         
                      
                      
                   
                      </Columns>
                 
                 
                      <HeaderStyle CssClass="cabezabrilla" />
                            <RowStyle BackColor="#EFF3FB" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White"  />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                  <br/>
        
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