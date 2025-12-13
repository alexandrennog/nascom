# nascom


Para a versão 2.1.1.37 foram incluídas as seguintes funcionalidades

1 - Ajuste de casas decimais
2 - Envio de Email de fechamento
3 - criptografia para senhas de usuários
4 - Recuperação de senha



Para a versão 2.1.2.3 foram incluídas as seguintes funcionalidades

1 - Permissão para aplicar descontos na ultima tela
2 - Permissão para excluir ou editar uma linha na tela de caixa
3 - No relatório Vendas SAT colocar divisão por cartão/dinheiro/pix/etc
incluir dinheiro, cheque, pix, debito, credito, crediario"


Para a versão 2.1.2.4 foram incluídas as seguintes funcionalidades

1 - Criação do relatório de vendas SAT


Para a versão 2.1.2.5 foram incluídas as seguintes funcionalidades

1 - Ajustar banco de dados vazio adicionar campo txID na tela de pagamento de crediário por Pix
2 - Recuperar o endereço principal do cliente
3 - Validar CPF no cadastro do cliente
4 - Incluir endereço na tela de clientes
5 - Na telas de venda e crediário Pesquisar por número do cliente
6 - Não imprimir data na etiqueta
7 - Bloquear a alteração de valores e datas de parcelar na tela de pagamento de crediário <F3>:


Para a versão 2.1.2.6 foram incluídas as seguintes funcionalidades

1 - Criar busca por código do cliente
2 - Recuperar somente consições ativas
3 - Bloquear alterações de valores e datas a parcelas
4 - Recuperar o endereço principal 
5 - Criação da coluna txID na tabela credpag
6 - Aumentar o tamnho do campo RG
7 - Validar o CPF em tempo de cadastro



Para a versão 2.1.2.7 foram incluídas as seguintes funcionalidades

1 - Tornar funcional a tela de pré-vendas
2 - Ajustar somas no relatório de estoque,  incluir o campo cor bem como ordenar e agrupar as informações


Para a versão 2.1.2.8 foram incluídas as seguintes funcionalidades

1 - Ajuste do label total estoque no relatório de estoque
2 - Evitar que uma parcela seja baixada mais de uma vez



Para a versão 2.1.2.9 foram incluídas as seguintes funcionalidades

1 - Ajuste do label falta pagar em parcelas de crediário abertas
2 - Inclusão de validação de alçada para descontos na tela de pagamento 
3 - Incluir opção de reimprimir etiquetas já impressas
4 - Após TAB no campo código do cliente carregar o nome do cliente 


Para a versão 2.1.3.0 foram incluídas as seguintes funcionalidades

1 - Incluídos os relatório de vendas por vendedor e por loja

Implantação:
a - incluir no arquivo nascomercio.exe.config a TAG:
   <add key="exibirRelsExcecao" value="SIM"/>
b - executar no mysql os scripts:
27 - objetos_relatorios.sql
28 - txID.sql
Colar na pasta Nasoomercio os arquivos da nova versão 
     
	 
Para a versão 2.0.0.0 

1 - Criado a funcionalidade	de NFe 

Implantação: 

   a - alterar no config a tag "FISCAL" value="ONLINE" /> 
   b - atualizar os arquivos da aplicação
   c - rodar os scripts de banco de número 28 e 29
   d - Adicionar as TAGs ao arquivo de configuração:
        <add key="pathRelatorio" value="C:\NascomercioNFe\" />
		<add key="CertificadoArquivo" value="C:\\cert\\********.pfx" />
		<add key="CertificadoSenha" value="831552" />
		<add key="TipoAmbiente" value="1" />
		<add key="UsaCertificadoDigital" value="1" />
		<add key="CSC" value="**************" />
		<add key="CSCIDToken" value="1" />
		<add key="SchemaVersao" value="4.00" />
		<add key="VersaoConfiguracao" value="4.00" />
		<add key="CNPJ" value="**************" />