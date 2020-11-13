Enum ColunasGrid_grdDocumentos As Integer
    Selecionar
    ID_DOCUMENTOS
    buttons
End Enum
Partial Class _Default
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
        End If
        Validacao.Outros(txtRGAluno, False, "RG do Aluno",, Validacao.eFormato.RG)
        Validacao.Outros(txttelresponsavel, False, "Tel Responsavel",, Validacao.eFormato.CELULAR)
        Validacao.Outros(txtcpfpai, False, "CPF",, Validacao.eFormato.CPF)
        Validacao.Outros(txtCPFmae, False, "CPF",, Validacao.eFormato.CPF)
        JavaScript.ExibirConfirmacao(btnSalvar, eTipoConfirmacao.SALVAR)
    End Sub

#Region "Funções de Cadastro"
    Private Function VerificarDoc() As Boolean
        Dim objDocumentos As New Documentos
        Dim Existe As Boolean = False

        With objDocumentos.Pesquisar(,,, Replace(Replace(txtRGAluno.Text, ".", ""), "-", ""))
            If .Rows.Count > 0 Then
                MsgBox("Documento já Cadastrado", eCategoriaMensagem.ALERTA)
                Existe = True
            End If
        End With

        objDocumentos = Nothing
        Return Existe
    End Function

    Private Sub LimparCampos()

        txtRGAluno.Text = ""
        txtIDAluno.Text = ""
        txtDNA.Text = ""
        txtDataEmissaoRGAluno.Text = ""
        txtnomemae.Text = ""
        txtCPFmae.Text = ""
        txtnomepai.Text = ""
        txtcpfpai.Text = ""
        txttelresponsavel.Text = ""
        txtDataHoradoCadastro.Text = ""

        dropSexo.ClearSelection()

        txtRGAluno.Focus()
    End Sub

    Private Sub Salvar()
        Dim objDocumentos As New Documentos(ViewState("Codigo"))
        With objDocumentos
            .IDAluno = Trim(Validacao.RetirarEspacos(txtIDAluno.Text))
            If VerificarDoc() = True Then
                Exit Sub
            End If
            .CPFdaMae = Replace(Replace(txtCPFmae.Text, ".", ""), "-", "")
            .CPFdoPai = Replace(Replace(txtcpfpai.Text, ".", ""), "-", "")
            .DNA = Replace(Replace(txtDNA.Text, ".", ""), ".", "")
            .RGdoAluno = Replace(Replace(txtRGAluno.Text, "", ""), ".", "")
            .SexoAluno = dropSexo.SelectedValue
            .NomedaMae = txtnomemae.Text
            .NomedoPai = txtnomepai.Text
            .IDAluno = txtIDAluno.Text
            .TelefoneResponsavel = txttelresponsavel.Text
            .DTEmissaoRGAluno = Replace(Replace(txtDataEmissaoRGAluno.Text, ".", ""), ".", "")

            .Salvar()
        End With
        objDocumentos = Nothing
    End Sub

    Private Sub Excluir(ByVal CodigoDocumentos As Integer)
        Dim objDocumentos As New Documentos

        If objDocumentos.Excluir(CodigoDocumentos) > 0 Then
            MsgBox(eTipoMensagem.EXCLUIR_SUCESSO)
        Else
            MsgBox(eTipoMensagem.EXCLUIR_ERRO)
        End If

        objDocumentos = Nothing

        LimparCampos()
        CarregarGrid()
    End Sub

    Private Sub Voltar()
        Response.Redirect(Request.Url.ToString)

        LimparCampos()
    End Sub
#End Region

#Region "Eventos de Cadastro"

    Protected Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Salvar()
        LimparCampos()
        CarregarGrid()
    End Sub
#End Region

#Region "Funções de Listagem"
    Private Sub CarregarGrid()
        Dim objDocumentos As New Documentos

        grdDocumentos.DataSource = objDocumentos.Pesquisar(ViewState("OrderBy"))
        grdDocumentos.DataBind()

        objDocumentos = Nothing

        lblRegistrosdoc.Text = DirectCast(grdDocumentos.DataSource, Data.DataTable).Rows.Count & " registro(s)"
    End Sub
#End Region

#Region "Eventos de Listagem"
    Protected Sub grdDocumentos_RowCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDocumentos.RowCommand
        If e.CommandName = "" Then
            Response.Redirect(Request.Url.ToString)
        ElseIf e.CommandName = "EXCLUIR" Then
            Excluir(grdDocumentos.DataKeys(e.CommandArgument).Item(0))
        End If
    End Sub

    Private Sub grdTurma_PageIndexChanging(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDocumentos.PageIndexChanging
        grdDocumentos.PageIndex = e.NewPageIndex
        CarregarGrid()
    End Sub

    Private Sub grdTurma_Sorting(ByVal source As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdDocumentos.Sorting
        ViewState("OrderByDirection") = IIf(ViewState("OrderByDirection") = "asc", "desc", "asc")
        ViewState("OrderBy") = e.SortExpression & " " & ViewState("OrderByDirection")
        CarregarGrid()
    End Sub

    Private Sub grdDocumentos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDocumentos.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow

                Dim lnkExcluirDocumento As New LinkButton
                lnkExcluirDocumento = DirectCast(e.Row.Cells(ColunasGrid_grdDocumentos.buttons).FindControl("lnkExcluirDocumento"), LinkButton)
                lnkExcluirDocumento.CommandArgument = e.Row.RowIndex
                lnkExcluirDocumento = Nothing

        End Select
    End Sub



#End Region
End Class
