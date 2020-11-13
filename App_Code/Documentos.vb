Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Text


Public Class Documentos
    Private CI02_ID_DOCUMENTOS As Integer
    Private CI01_ID_ALUNO As String
    Private CI02_NM_MAE As String
    Private CI02_NU_CPF_MAE As String
    Private CI02_NM_PAI As String
    Private CI02_NU_CPF_PAI As String
    Private CI02_NU_TELEFONE_RESPONSAVEL As String
    Private CI02_NU_RG_ALUNO As String
    Private CI02_DT_EMISSAO_RG_ALUNO As String
    Private CI02_DT_NASCIMENTO_ALUNO As String
    Private CI02_TP_SEXO_ALUNO As String
    Private CI02_DH_CADASTRO As String


    Public Property Codigodoc() As Integer
        Get
            Return CI02_ID_DOCUMENTOS
        End Get
        Set(ByVal Value As Integer)
            CI02_ID_DOCUMENTOS = Value
        End Set
    End Property

    Public Property IDAluno() As String
        Get
            Return CI01_ID_ALUNO
        End Get
        Set(ByVal Value As String)
            CI01_ID_ALUNO = Value
        End Set
    End Property

    Public Property NomedaMae() As String
        Get
            Return CI02_NM_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NM_MAE = Value
        End Set
    End Property
    Public Property CPFdaMae() As String
        Get
            Return CI02_NU_CPF_MAE
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_MAE = Value
        End Set
    End Property
    Public Property NomedoPai() As String
        Get
            Return CI02_NM_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NM_PAI = Value
        End Set
    End Property
    Public Property CPFdoPai() As String
        Get
            Return CI02_NU_CPF_PAI
        End Get
        Set(ByVal Value As String)
            CI02_NU_CPF_PAI = Value
        End Set
    End Property
    Public Property TelefoneResponsavel() As String
        Get
            Return CI02_NU_TELEFONE_RESPONSAVEL
        End Get
        Set(ByVal Value As String)
            CI02_NU_TELEFONE_RESPONSAVEL = Value
        End Set
    End Property
    Public Property RGdoAluno() As String
        Get
            Return CI02_NU_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_NU_RG_ALUNO = Value
        End Set
    End Property
    Public Property DTEmissaoRGAluno() As String
        Get
            Return CI02_DT_EMISSAO_RG_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_EMISSAO_RG_ALUNO = Value
        End Set
    End Property
    Public Property DNA() As String
        Get
            Return CI02_DT_NASCIMENTO_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_DT_NASCIMENTO_ALUNO = Value
        End Set
    End Property
    Public Property SexoAluno() As String
        Get
            Return CI02_TP_SEXO_ALUNO
        End Get
        Set(ByVal Value As String)
            CI02_TP_SEXO_ALUNO = Value
        End Set
    End Property
    Public Property DHCadastro() As String
        Get
            Return CI02_DH_CADASTRO
        End Get
        Set(ByVal Value As String)
            CI02_DH_CADASTRO = Value
        End Set
    End Property

    Public Sub New(Optional ByVal Codigodoc As Integer = 0)
        If Codigodoc > 0 Then
            Obter(Codigodoc)
        End If
    End Sub

    Public Sub Salvar()
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Codigodoc)

        dt = cnn.EditarDataTable(strSQL.ToString)

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
        Else
            dr = dt.Rows(0)
        End If

        dr("CI02_ID_DOCUMENTOS") = ProBanco(CI02_ID_DOCUMENTOS, eTipoValor.CHAVE)
        dr("CI01_ID_ALUNO") = ProBanco(CI01_ID_ALUNO, eTipoValor.TEXTO)
        dr("CI02_NM_MAE") = ProBanco(CI02_NM_MAE, eTipoValor.TEXTO_LIVRE)
        dr("CI02_NU_CPF_MAE") = ProBanco(CI02_NU_CPF_MAE, eTipoValor.TEXTO)
        dr("CI02_NM_PAI") = ProBanco(CI02_NM_PAI, eTipoValor.TEXTO_LIVRE)
        dr("CI02_NU_CPF_PAI") = ProBanco(CI02_NU_CPF_PAI, eTipoValor.TEXTO)
        dr("CI02_NU_TELEFONE_RESPONSAVEL") = ProBanco(CI02_NU_TELEFONE_RESPONSAVEL, eTipoValor.TEXTO)
        dr("CI02_NU_RG_ALUNO") = ProBanco(CI02_NU_RG_ALUNO, eTipoValor.TEXTO)
        dr("CI02_DT_EMISSAO_RG_ALUNO") = ProBanco(CI02_DT_EMISSAO_RG_ALUNO, eTipoValor.TEXTO_LIVRE)
        dr("CI02_DT_NASCIMENTO_ALUNO") = ProBanco(CI02_DT_NASCIMENTO_ALUNO, eTipoValor.TEXTO_LIVRE)
        dr("CI02_TP_SEXO_ALUNO") = ProBanco(CI02_TP_SEXO_ALUNO, eTipoValor.TEXTO_LIVRE)
        dr("CI02_DH_CADASTRO") = ProBanco(CI02_DH_CADASTRO, eTipoValor.TEXTO_LIVRE)

        cnn.SalvarDataTable(dr)

        dt.Dispose()
        dt = Nothing

        cnn = Nothing
    End Sub

    Public Sub Obter(ByVal Codigodoc As Integer)
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim dr As DataRow
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Codigodoc)

        dt = cnn.AbrirDataTable(strSQL.ToString)

        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            CI02_ID_DOCUMENTOS = DoBanco(dr("CI02_ID_DOCUMENTOS"), eTipoValor.CHAVE)
            CI01_ID_ALUNO = DoBanco(dr("CI01_ID_ALUNO"), eTipoValor.TEXTO)
            CI02_NM_MAE = DoBanco(dr("CI02_NM_MAE"), eTipoValor.TEXTO_LIVRE)
            CI02_NU_CPF_MAE = DoBanco(dr("CI02_NU_CPF_MAE"), eTipoValor.TEXTO)
            CI02_NM_PAI = DoBanco(dr("CI02_NM_PAI"), eTipoValor.TEXTO_LIVRE)
            CI02_NU_CPF_PAI = DoBanco(dr("CI02_NU_CPF_PAI"), eTipoValor.TEXTO)
            CI02_NU_TELEFONE_RESPONSAVEL = DoBanco(dr("CI02_NU_TELEFONE_RESPONSAVEL"), eTipoValor.TEXTO)
            CI02_NU_RG_ALUNO = DoBanco(dr("CI02_NU_RG_ALUNO"), eTipoValor.TEXTO)
            CI02_DT_EMISSAO_RG_ALUNO = DoBanco(dr("CI02_DT_EMISSAO_RG_ALUNO"), eTipoValor.TEXTO_LIVRE)
            CI02_DT_NASCIMENTO_ALUNO = DoBanco(dr("CI02_DT_NASCIMENTO_ALUNO"), eTipoValor.TEXTO_LIVRE)
            CI02_TP_SEXO_ALUNO = DoBanco(dr("CI02_TP_SEXO_ALUNO"), eTipoValor.TEXTO_LIVRE)
            CI02_DH_CADASTRO = DoBanco(dr("CI02_DH_CADASTRO"), eTipoValor.TEXTO_LIVRE)
        End If

        cnn = Nothing
    End Sub

    Public Function Pesquisar(Optional ByVal Sort As String = "",
                              Optional ByVal Codigodoc As Integer = 0,
                              Optional ByVal NomeAluno As String = "",
                              Optional ByVal NomedaMae As String = "",
                              Optional ByVal CPFdaMae As String = "",
                              Optional ByVal NomedoPai As String = "",
                              Optional ByVal CPFdoPai As String = "",
                              Optional ByVal TelefoneResponsavel As String = "",
                              Optional ByVal RGdoAluno As String = "",
                              Optional ByVal DTEmissaoRGAluno As String = "",
                              Optional ByVal DNA As String = "",
                              Optional ByVal SexoAluno As String = "",
                              Optional ByVal DHCadastro As String = "") As DataTable
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder

        strSQL.Append(" select * ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS is not null")

        If Codigodoc > 0 Then
            strSQL.Append(" and CI02_ID_DOCUMENTOS = " & Codigodoc)
        End If

        If NomeAluno <> "" Then
            strSQL.Append(" and upper(CI01_ID_ALUNO) like '%" & NomeAluno.ToUpper & "%'")
        End If

        If NomedaMae <> "" Then
            strSQL.Append(" and upper(CI02_NM_MAE) like '%" & NomedaMae.ToUpper & "%'")
        End If

        If CPFdaMae <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_MAE) like '%" & CPFdaMae.ToUpper & "%'")
        End If

        If NomedoPai <> "" Then
            strSQL.Append(" and upper(CI02_NM_PAI) like '%" & NomedoPai.ToUpper & "%'")
        End If

        If CPFdoPai <> "" Then
            strSQL.Append(" and upper(CI02_NU_CPF_PAI) like '%" & CPFdoPai.ToUpper & "%'")
        End If

        If TelefoneResponsavel <> "" Then
            strSQL.Append(" and upper(CI02_NU_TELEFONE_RESPONSAVEL) like '%" & TelefoneResponsavel.ToUpper & "%'")
        End If

        If RGdoAluno <> "" Then
            strSQL.Append(" and upper(CI02_NU_RG_ALUNO) like '%" & RGdoAluno.ToUpper & "%'")
        End If

        If DTEmissaoRGAluno <> "" Then
            strSQL.Append(" and upper(CI02_DT_EMISSAO_RG_ALUNO) like '%" & DTEmissaoRGAluno.ToUpper & "%'")
        End If

        If DNA <> "" Then
            strSQL.Append(" and upper(CI02_DT_NASCIMENTO_ALUNO) like '%" & DNA.ToUpper & "%'")
        End If

        If SexoAluno <> "" Then
            strSQL.Append(" and upper(CI02_TP_SEXO_ALUNO) like '%" & SexoAluno.ToUpper & "%'")
        End If

        If DHCadastro <> "" Then
            strSQL.Append(" and upper(CI02_DH_CADASTRO) like '%" & DHCadastro.ToUpper & "%'")
        End If

        strSQL.Append(" Order By " & IIf(Sort = "", "CI02_ID_DOCUMENTOS", Sort))

        Return cnn.AbrirDataTable(strSQL.ToString)
    End Function

    Public Function ObterTabela() As DataTable
        Dim cnn As New Conexao
        Dim dt As DataTable
        Dim strSQL As New StringBuilder

        strSQL.Append(" select CI02_ID_DOCUMENTOS as CODIGODOC, CI01_ID_ALUNO as DESCRICAO")
        strSQL.Append(" from CI01_ALUNO")

        dt = cnn.AbrirDataTable(strSQL.ToString)

        '
        cnn = Nothing

        Return dt
    End Function

    Public Function ObterUltimo() As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim CodigoUltimo As Integer

        strSQL.Append(" select max(CI02_ID_DOCUMENTOS) from CI02_DOCUMENTOS")

        With cnn.AbrirDataTable(strSQL.ToString)
            If Not IsDBNull(.Rows(0)(0)) Then
                CodigoUltimo = .Rows(0)(0)
            Else
                CodigoUltimo = 0
            End If
        End With

        '
        cnn = Nothing

        Return CodigoUltimo

    End Function

    Public Function Excluir(ByVal Codigodoc As Integer) As Integer
        Dim cnn As New Conexao
        Dim strSQL As New StringBuilder
        Dim LinhasAfetadas As Integer

        strSQL.Append(" delete ")
        strSQL.Append(" from CI02_DOCUMENTOS")
        strSQL.Append(" where CI02_ID_DOCUMENTOS = " & Codigodoc)

        LinhasAfetadas = cnn.ExecutarSQL(strSQL.ToString)

        '
        cnn = Nothing

        Return LinhasAfetadas
    End Function

End Class
