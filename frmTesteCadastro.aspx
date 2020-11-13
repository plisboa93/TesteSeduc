<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmTesteCadastro.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
 </section>
   <section class="content">
      <h4 class="page-header">Formulario Cadastro de Documentos</h4>
         <div class="box-body">
            <div class="row">
               <div class="col-md-6">
                  <div class="form-group">
                      
                     <label for="IDAluno">ID do Aluno:</label>
                     <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtIDAluno" name="IDAluno" placeholder="Ex.: 10" maxlength="20"/>
                  </div>
               </div>
               <div class="col-md-2">
                 <div class="form-group">
                      <label for="DNA">Data de Nascimento do Aluno:</label>
                      <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtDNA" name="DNA" placeholder="Ex.: 01/01/2000" maxlength="10"/>
                 </div>
               </div>
            </div> 


            <div class="row">
               <div class="col-md-2">
                   <div class="form-group">
                       <label for="RGdoAluno">RG do Aluno:</label>
                       <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtRGAluno" name="RGdoAluno" placeholder="Ex.: 12345678901.12" maxlength="13" />
                   </div>
               </div>
               <div class="col-md-2">
                  <div class="form-group">
                      <label for="DTEmissaoRGAluno">Data de Emisão do RG do Aluno:</label>
                      <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtDataEmissaoRGAluno" name="DTEmissaoRGAluno" placeholder="Ex.: 01/01/2010" maxlength="10"/>
                   </div>
               </div>
               <div class="col-md-2">
                  <div class="form-group">
                       <label for="SexoAluno">Sexo:</label>
                       <asp:DropDownList runat="server" required="required" id="dropSexo" class="form-control" name="Sexo">
                            <asp:ListItem value="">Selecione</asp:ListItem>
                            <asp:ListItem value="">Feminino</asp:ListItem>
                            <asp:ListItem value="">Masculino</asp:ListItem>
                       </asp:DropDownList>
                  </div>
               </div>
            </div>


            <div class="row">
               <div class="col-md-6">
                  <div class="form-group">
                      <label for="NomedaMae">Nome da Mãe:</label>
                       <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtnomemae" name="NomedaMae" placeholder="Ex.: Maria Joana" maxlength="50"/>
                   </div>
                </div>
                <div class="col-md-2">
                   <div class="form-group">
                        <label for="CPFdaMae">CPF - Mãe:</label>
                        <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtCPFmae" name="CPFdaMae" placeholder="Ex.: xxx.xxx.xxx-xx" maxlength="11" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
               <div class="form-group">
                     <label for="NomedoPai">Nome do Pai:</label>
                     <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtnomepai" name="NomedoPai" placeholder="Ex.: Marcio João" maxlength="50"/>
                </div>
             </div>
         </div>


           <div class="row">
             <div class="col-md-2">
                <div class="form-group">
                    <label for="CPFdoPai">CPF - Pai:</label>
                    <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtcpfpai" name="CPFdoPai" placeholder="Ex.: xxx.xxx.xxx-xx" maxlength="11" />
                </div>
             </div>
           </div>


           <div class="row">
              <div class="col-md-2">
                 <div class="form-group">
                        <label for="TelefoneResponsavel">Telefone do Responsável:</label>
                        <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txttelresponsavel" name="TelefoneResponsavel" placeholder="Ex.: (12) 34567-8910" maxlength="14"/>
                 </div>
              </div>
           </div>
           
       
       <div class="row">
              <div class="col-md-2">
                 <div class="form-group">
                        <label for="DHCadastro">Data e Hora do Cadastro:</label>
                        <asp:TextBox runat="server" required="required" type="text" class="form-control" id="txtDataHoradoCadastro" name="DHCadastro" placeholder="Ex.: 02/08/2020 - 14:00" maxlength="20"/>
                 </div>
              </div>
           </div>
             <div class="box-footer">
                <div class="col-md-6">
                    <asp:Button class="btn btn-primary" runat="server" ID="btnSalvar" Text="Salvar" />
                </div>
             </div>


        <div class="box-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblRegistrosdoc" runat="server" CssClass="badge bg-aqua" />
                    <asp:GridView id="grdDocumentos" runat="server" CssClass="table table-bordered" PagerStyle-CssClass="paginacao" AllowSorting="True" AllowPaging="True" PageSize="20" AutoGenerateColumns="False" DataKeyNames="CI02_DOCUMENTOS">
	                    <HeaderStyle CssClass="bg-aqua" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="CI02_ID_DOCUMENTOS" SortExpression="CI02_ID_DOCUMENTOS" HeaderText="Codigo do Documento"/>
                            <asp:BoundField DataField="CI02_ID_ALUNO" SortExpression="CI01_ID_ALUNO" HeaderText="Codigo do Aluno" />
                            <asp:BoundField DataField="CI01_NM_ALUNO" SortExpression="CI01_NM_ALUNO" HeaderText="Nome do Aluno"/>
                            <asp:BoundField DataField="CI02_NU_RG_ALUNO" SortExpression="CI02_NU_RG_ALUNO" HeaderText="RG do Aluno" DataFormatString="{0:###########-##}"/>
		                    <asp:BoundField DataField="CI02_NM_MAE" SortExpression="CI02_NM_MAE" HeaderText="Nome da Mãe"/>
                            <asp:BoundField DataField="CI02_NU_CPF_MAE" SortExpression="CI02_NU_CPF_MAE" HeaderText="CPF da Mãe" DataFormatString="{0:###.###.###-##}"/>
                            <asp:BoundField DataField="CI02_NM_PAI" SortExpression="CI02_NM_PAI" HeaderText="Nome do Pai"/>
                            <asp:BoundField DataField="CI02_NU_CPF_PAI" SortExpression="CI02_NU_CPF_PAI" HeaderText="CPF da Pai" DataFormatString="{0:###.###.###-##}"/>
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="true" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <div class="btn-group">
                                        <asp:LinkButton ID="lnkExcluirDocumento" runat="server" class="btn btn-social-icon bg-red" CommandName="EXCLUIR" ToolTip="ExcluirDocumento">
                                            <i id="iExcluirDocumento" runat="server" class="fa fa-mortar-board"></i>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
