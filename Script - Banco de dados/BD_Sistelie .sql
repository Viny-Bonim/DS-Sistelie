#GRUPO: SISTEMA SISTELIÊ

#NOME: Carol Aparecida de Souza Barros, Gabriel André Estevam Gross,
       #Gustavo dos Anjos Neri, Hiago Santana Benitez, Viny Bonim Scaldelai.
       
#REQUISITOS FUNCIONAIS: Cadastrar cliente,	Registrar Despesas, Consultar Despesas, Tarefas, Consultar Clientes, 
#Fazer Login, Registrar vendas, Exibir Vendas, Exibir Painel Inicial, Cadastrar Fornecedor, Consultar Fornecedor,	
#Cadastrar Matéria - Prima,	Consultar Matéria-Prima, Cadastrar Funcionário,	Controlar Caixa, Consultar Funcionário,	Agendar Pedido,

#BANCO DE DADOS:

create database BD_Sistelie;
use BD_Sistelie;

create table Endereco(
cod_endereco int not null primary key auto_increment,
cep varchar(8) not null,
logradouro varchar(100) not null,
numero varchar(15) not null,
pais varchar (50) not null,
uf varchar(2) not null,
cidade varchar(100) not null
);
insert into Endereco values (null, 76908494, 't-12', 1231, 'Brasil', 'RO', 'Ji-Paraná');


create table Tarefa(
cod_tare integer not null primary key auto_increment,
tipo_tare varchar (200) not null,
responsavel_tare varchar (20) not null,
datainicio_tare date,
datatermi_tare date,
descricao_tare varchar (300) not null
);
insert into Tarefa values (null, 'confecção', 'Viny', '2021-08-10', '2021-08-15', 'confeccionar 30 convites preto e amarelo para casamento');


create table Funcionario(
cod_func int not null primary key auto_increment,
nome varchar (200) not null,
cpf varchar (11) not null,
rg varchar (9) not null,
data_nasc_func date,
sexo varchar (50) not null,
telefone varchar (50) not null,
email varchar (100) not null,
cod_endereco_fk int not null,
cod_tare_fk int not null,
foreign key (cod_endereco_fk) references Endereco (cod_endereco),
foreign key (cod_tare_fk) references Tarefa (cod_tare)
);
insert into Funcionario values (null, 'Viny', 03678986644, 67848334, '2003-05-03', 'Masculino', '999707968', 'Viny123@gmail.com', 1, 1);


create table Caixa(
cod_caixa integer not null primary key auto_increment,
saldo_inicial_caixa double,
entrada_caixa double,
saida_caixa double,
saldo_final double,
cod_func_fk int not null,
foreign key (cod_func_fk) references Funcionario (cod_func)
);
insert into Caixa values (null, 1000.00, 2000.00, 500.00, 2500.00, 1);


create table Produto(
cod_produto integer not null primary key auto_increment,
estoque_produto int,
valor_produto double not null,
descricao_produto varchar(300) not null,
nome_produto varchar(200) not null
);
insert into Produto values (null, 20, 3.00, 'convite para casamento preto e amarelo', 'convite');


create table Despesa(
cod_desp int not null primary key auto_increment,
valor_desp double not null,
data_desp date not null,
descricao_desp varchar(500),
grupo_desp varchar(30),
cod_caixa_fk int not null,
cod_func_fk int not null,
foreign key (cod_caixa_fk) references Caixa(cod_caixa),
foreign key (cod_func_fk) references Funcionario(cod_func)
);
insert into Despesa values (null, 500.00, '2021-08-03', 'água', 'fixa', 1, 1);


create table Fornecedor (
cod_forn int not null primary key auto_increment,
email_forn varchar(150),
tipo_forn varchar(50) not null,
data_cadastro_forn date not null,
rg_ie_forn varchar(30) not null,
cpf_cnpj_forn varchar(30) not null,
nome_fantasia_forn varchar(100),
razao_social_forn varchar(200),
telefone_forn varchar(30),
cod_endereco_fk int not null,
foreign key (cod_endereco_fk) references Endereco(cod_endereco)
);
insert into Fornecedor values (null, 'fornece123@gmail.com', 'pessoa jurídica', '2021-07-20', 8954059433344234, 123234859485, 'papelaria ia ia', 'papelaria ia ia', 999865743, 1);


create table Cliente (
cod_clien int not null primary key auto_increment,
nome_clien varchar (200) not null,
cpf_clien varchar (11) not null,
rg_clien varchar (12),
datanasc_clien date,
sexo_clien varchar (50),
telefone_cli varchar (50),
email_clien varchar (100),
cod_endereco_fk int not null,
foreign key (cod_endereco_fk) references Endereco(cod_endereco)
);
insert into Cliente values (null, 'João', 99654832945, 493847509, '2004-06-21', 'masculino', 992123434, 'Joao1234@gmail.com', 1); 


create table MateriaPrima(
cod_cad_mat_prima int not null primary key auto_increment,
data_cad date,
valor_unitario double not null,
estoque int not null,
nome_mat varchar (200) not null
);
insert into MateriaPrima values (null, '2021-08-31', 3.00, 20, 'Papelão Paraná 20mm');


create table ForneceMateriaPrima(
cod_fornec_mat_prima int not null primary key auto_increment,
cod_forn_fk int not null,
cod_cad_mat_prima_fk int not null,
foreign key(cod_forn_fk) references Fornecedor(cod_forn),
foreign key(cod_cad_mat_prima_fk) references MateriaPrima(cod_cad_mat_prima)
);
insert into ForneceMateriaPrima values (null, 1, 1);


create table Fabricar(
cod_fabricar int not null primary key auto_increment,
custo_fabricar double not null,
cod_produto_fk int not null,
foreign key (cod_produto_fk) references Produto (cod_produto)
);
insert into Fabricar values (null, 10.00, 1);


create table MateriaPrimaFabricar(
cod_mat_prima_fab int not null primary key auto_increment,
qtd int not null,
cod_cad_mat_prima_fk int not null,
cod_fabricar_fk int not null,
foreign key (cod_cad_mat_prima_fk) references MateriaPrima (cod_cad_mat_prima),
foreign key (cod_fabricar_fk) references Fabricar (cod_fabricar)
);
insert into MateriaPrimaFabricar values (null, 30, 1, 1);


create table Pedido(
cod_pedido int not null primary key auto_increment,
status_pedido varchar (200) not null, 
praso_entrega date,
data_pedido date,
nome_cliente varchar (200) not null, 
nome_funcionario varchar (200) not null,
descricao_pedido varchar(200) not null,
quantidade_intens int not null,
cod_clien_fk int not null,
cod_func_fk int not null, 
cod_produto_fk int not null,
foreign key (cod_clien_fk) references Cliente (cod_clien),
foreign key (cod_func_fk) references Funcionario (cod_func),
foreign key (cod_produto_fk) references Produto (cod_produto)
);
Insert into Pedido values (null, 'em andamento', '2021-08-15', '2021-08-10', 'Mario', 'Viny', 'convite para casamento preto e amarelo', 10, 1, 1, 1);


create table Venda(
cod_venda int not null primary key auto_increment,
unidade_venda varchar(200) not null,
valor_desconto double,
data_venda date,
valor_unidade double not null,
forma_pagamento varchar (200) not null,
nome_cliente varchar (200) not null,
nome_vendedor varchar (200) not null,
descricao_venda varchar (200) not null,
quantidade_unidade int,
valor_total_venda double not null,
cod_pedido_fk int not null,
cod_clien_fk int not null,
cod_func_fk int not null,
cod_caixa_fk int not null,
cod_produto_fk int not null,
foreign key (cod_pedido_fk) references Pedido (cod_pedido),
foreign key (cod_clien_fk) references Cliente (cod_clien),
foreign key (cod_func_fk) references Funcionario (cod_func),
foreign key (cod_caixa_fk) references Caixa (cod_caixa),
foreign key (cod_produto_fk) references Produto (cod_produto)
);
insert into Venda values (null, 'Convite', 5.00, '2021-08-16', 3.00, 'à vista', 'João', 'Viny', 'convite para casamento preto e amarelo', 10, 25.00, 1, 1, 1, 1, 1);


create table VendaProduto(
cod_venda_pro int not null primary key auto_increment,
cod_produto_fk int not null,
cod_venda_fk int not null,
foreign key (cod_produto_fk) references Produto (cod_produto),
foreign key (cod_venda_fk) references Venda (cod_venda)
);
insert into VendaProduto values (null, 1, 1);


create table PedidoVenda(
cod_ped_ven int not null primary key auto_increment,
cod_pedido_fk int not null,
cod_venda_fk int not null,
foreign key (cod_pedido_fk) references Pedido (cod_pedido),
foreign key (cod_venda_fk) references Venda (cod_venda)
);
insert into PedidoVenda values (null, 1, 1);


create table Login(
cod_log int not null primary key auto_increment,
nome varchar (200) not null,
senha varchar (200) not null,
cod_func_fk int not null,
foreign key (cod_func_fk) references Funcionario (cod_func)
);
insert into Login values (null, 'Viny', '1234wasd',1); 

################################################################################################################################################################################

#PROCEDIMENTO DA TABELA ENDEREÇO:

delimiter $$
create procedure InserirEndereco (cepEnd varchar(8), logradouroEnd varchar(100), numeroEnd varchar(15), paisEnd varchar(50), ufEnd varchar(2), cidadeEnd varchar(100))
begin
if (cepEnd > 0) then
	if (numeroEnd > 0) then
		insert into Endereco values (null, cepEnd, logradouroEnd, numeroEnd, paisEnd, ufEnd, cidadeEnd);
        select concat('Endereço Cadastrado com Sucesso!') as Confirmacao;
	else
		select concat('Por favor informe o número do local.') as Alerta;
	end if;
else
	select concat('Por favor informe o cep do local.') as Alerta;
end if;
end;
$$ delimiter ;
call InserirEndereco ('12345679', 'Rua 1', '1874', 'Canadá', 'OT', 'Toronto');
select * from endereco;

################################################################################################################################################################################

#PROCEDIMENTO DA TABELA TAREFA:

delimiter $$ 
create procedure InserirTarefa(tipo varchar (200), responsavel varchar(20), data_inicio date, data_termino date, descricao varchar(50))
begin
if(data_inicio <= data_termino) then
	if(descricao is not null) then 
		insert into Tarefa values (null, tipo, responsavel, data_inicio, data_termino, descricao);
        select concat('Descrição inserida com sucesso!') as Confirmacao;
	
    else
		select concat('insira uma descrição!') Alerta;
        
	end if;
    
else
	select concat('A data de termino deve ser maior que a data de início!') as Alerta;

end if;

end;

$$ delimiter ; 
call InserirTarefa ('confecção', 'Gabriel', '2021-08-10', '2021-08-10', 'confeccionar convites');
select * from tarefa;


################################################################################################################################################################################


#PROCEDIMENTO DA TABELA FUNCIONÁRIO:

delimiter $$
create procedure InserirFuncionario (nomeFunc varchar(200), cpfFunc varchar(20), rgFunc varchar(30), data_nascimento date, sexoFunc varchar (50), 
telefoneFunc varchar (50), emailFunc varchar (100), endereco int, tarefa int)
begin
declare verificanome varchar(200);
declare verifiendereco int;
set verificanome = (select nome from Funcionario where (nome = nomeFunc));
set verifiendereco = (select cod_endereco from Endereco where (cod_endereco = endereco));

if (verificanome is null) then
	if (verifiendereco is not null) then
		insert into Funcionario values (null, nomeFunc, cpfFunc, rgFunc, data_nascimento, sexoFunc, telefoneFunc, emailFunc, endereco, tarefa);
		select concat('Funcionário Cadastrado com Sucesso!') as Confirmacao;
    else
		select concat('Por favor informe um endereço válido para o cadastro!') as Alerta;
	end if;
else
	select concat('O funcionário com o nome: ', nomeFunc, ' já está cadastrado!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirFuncionario ('Gabriel Estevam', '03466992244', '185054', '2003-04-01', 'Masculino', '69993487522', 'gabriel@gmail.com', 1, 1);
select * from Funcionario;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA CAIXA:

delimiter $$
create procedure InserirCaixa (saldoIni double, entrada double, saida double, saldoFin double, funcionario int)
begin
declare verificaFuncionario int;
set verificaFuncionario = (select cod_func from Funcionario where (cod_func = funcionario));

if(entrada >= 0) then
	if (verificaFuncionario is not null) then
		insert into Caixa values (null, saldoIni, entrada, saida, saldoFin, funcionario);
        select concat('Caixa Cadastrado com Sucesso!') as Confirmacao;
	else
		select concat('O Funcionário informado não existe!') as Alerta;
	end if;
else
	select concat('O valor da entrada não pode ser negativo!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirCaixa (10, 800, 200, 600, 1);
select * from caixa;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA PRODUTO:

delimiter $$ 
create procedure  InserirProduto (estoque int, valor_pro double, descricao varchar(300), nome varchar(200))
begin
declare verificaNome varchar (200);
set verificaNome = (select nome_produto from Produto where (nome_produto = nome));

if (valor_pro > 0) then
	if(verificaNome is null) then
		insert into Produto values (null, estoque, valor_pro, descricao, nome);
        select concat('Produto inserido com sucesso!') Confirmacao;
        
	else
		select concat('Este nome já está cadastrado!') Alerta;
        
	end if;
    
else
	select concat('O valor do produto deve ser maior que 0!') Alerta;
    
end if;
end;
$$ delimiter ;
call InserirProduto (20, 3, 'Convite para casamento branco e preto', 'bilhete');  

select * from Produto;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA DESPESA:

delimiter $$
create procedure InserirDespesa (valor double, dataDesp date, descricao varchar(500), grupo varchar(30), codigo_do_caixa int, codigo_do_funcionario int)
begin
declare verificaCaixa int;
set verificaCaixa = (select cod_caixa from Caixa where (cod_caixa = (select max(cod_caixa) from caixa)));

if (valor > 0) then
	if (codigo_do_caixa > 0) and (codigo_do_caixa <= verificaCaixa) then
		insert into Despesa values (null, valor, dataDesp, descricao, grupo, codigo_do_caixa, codigo_do_funcionario);
        select concat('Despesa inserida com sucesso!') as Confirmacao;
	else
		select concat('Por favor informe um caixa válido para a despesa ser inserida!') as Alerta;
    end if;
else
	select concat('O valor da despesa não pode estar zerado ou negativo!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirDespesa (50, '2020-05-13', 'Reposição do estoque de Papelão Paraná', 'Variável', 1, 1);
select * from Despesa;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA FORNECEDOR:

delimiter $$
create procedure InserirFornecedor (email varchar(150), tipo varchar(50), data_de_cadastro date, rg_ie varchar(30), cpf_cnpj varchar(30), nome_fantasia varchar(100), 
razao_social varchar(200), telefone varchar(30), endereco int)
begin
declare verificaCpfCnpj varchar(200);
declare verificaRgIe varchar(200);
set verificaCpfCnpj = (select cpf_cnpj_forn from Fornecedor where (cpf_cnpj_forn = cpf_cnpj));
set verificaRgIe = (select rg_ie_forn from Fornecedor where (rg_ie_forn = rg_ie));

if (verificaRgIe is null) then 
	if (verificaCpfCnpj is null) then
		insert into Fornecedor values (null, email, tipo, data_de_cadastro, rg_ie, cpf_cnpj, nome_fantasia, razao_social, telefone, endereco);
		select concat('Fornecedor Cadastrado com Sucesso!') as Confirmacao;
    else
		select concat('O CNPJ/CPF informado, já está cadastrado!') as Alerta;
	end if;
else
	select concat('O RG/IE informado, já está cadastrado!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirFornecedor ('forncedor1@gmail.com', 'Pessoa física', '2018-05-25', '135854', '03368902244', 'Papelaria Tem de Tudo', 'Tem de Tudo Ltda', '69993498771', '1');
select * from fornecedor;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA CLIENTE:

delimiter $$ 
create procedure InserirCliente (nome_cliente varchar (200), cpf varchar (11), rg varchar (12), data_nascimento date, sexo varchar(50), telefone varchar (50),
email varchar (100), codigo_do_endereco int)
begin 
declare verificarNomeCliente varchar (200);
declare verificarCpf varchar (11);
set verificarNomeCliente = (select nome_clien from Cliente where (nome_clien = nome_cliente));
set verificarCpf = (select cpf_clien from Cliente where (cpf_clien = cpf));

if(verificarNomeCliente is null) then
	if(verificarCpf is null) then
		insert into Cliente values (null, nome_cliente, cpf, rg, data_nascimento, sexo, telefone, email, codigo_do_endereco);
        select concat('Cliente inserido com sucesso!') as Confirmação;
	
    else
		select concat('Já existe o cpf inserido!') AS Alerta;
	end if;
    
else 
	select concat('Já existe o nome inserido!') as Alerta;
    
end if;
end;
$$ delimiter ;
call InserirCliente ('mario', 33456789234, 213456789099, '2001-09-21', 'Masculino', 992134934, 'qweasd@gmail.com', 1);
select * from Cliente;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA MATERIAPRIMA:

delimiter $$ 
create procedure InserirMateriaPrima(data date, valor double, estoq int, nome varchar (200))
begin
if(valor > 0) then
	if(nome is not null) then 
		insert into MateriaPrima values (null, data, valor, estoq, nome);
        select concat('Matéria - prima inserida com sucesso!') as Confirmacao;
	
    else
		select concat('insira o nome da matéria - prima!') Alerta;
        
	end if;
    
else
	select concat('O valor da matéria prima deve ser maior que 0!') as Alerta;

end if;

end;

$$ delimiter ; 
call InserirMateriaPrima('2021-08-20', 3, 10, 'papelão');
select * from MateriaPrima;

############################################################################################################################################################################################

#POCEDIMENTO DA TABELA FORNECEMATERIAPRIMA:

delimiter $$
create procedure InserirForneceMateriaPrima (fornecedor int, materiaPrima int)
begin
declare verificaforne int;
declare verificaMatePrima int;
set verificaforne = (select cod_forn from Fornecedor where (cod_forn = fornecedor));
set verificaMatePrima = (select cod_cad_mat_prima from MateriaPrima where (cod_cad_mat_prima = materiaPrima));

if(verificaforne is not null) then
	if(verificaMatePrima is not null) then
		insert into ForneceMateriaPrima values (null, fornecedor, materiaPrima);
        select concat('ForneceMateriaPrima inserida com sucesso!') as Confirmacao;
	else
		select concat('Materia-Prima informada não existe!') as Alerta;
    end if;
else
	select concat('Fornecedor informado não existe!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirForneceMateriaPrima (1, 1);
select * from ForneceMateriaPrima;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA FABRICAR:

delimiter $$
create procedure InserirFabricar (custo double, produto int)
begin
declare verificaProduto int;
set verificaProduto = (select cod_produto from produto where (cod_produto = produto));

if (custo > 0) then
	if (verificaProduto is not null) then
		insert into Fabricar values (null, custo, produto);
        select concat('Fabricar inserido com sucesso!') as Confirmacao;
	else
		select concat('O produto informado não existe') as Alerta;
	end if;
else
	select concat('O custo deve ser MAIOR que 0') as Alerta;
end if;
end;
$$ delimiter ;
call InserirFabricar (150, 1);
select * from fabricar;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA MatériaPrimaFabricar:

delimiter $$
create procedure InserirMateriaPrimaFabricar (quantidade int, refer_matPrima int, refer_fabricar int)
begin
declare verificaMatPrima int;
declare verificaFabricar int;
set verificaMatPrima = (select cod_cad_mat_prima from materiaprima where (cod_cad_mat_prima = refer_matPrima));
set verificaFabricar = (select cod_fabricar from fabricar where (cod_fabricar = refer_fabricar));

if (verificaMatPrima is not null) then
	if (verificaFabricar is not null) then
		insert into MateriaPrimaFabricar values (null, quantidade, refer_matPrima, refer_fabricar);
        select concat('MateriaPrimaFabricar cadastrado com sucesso!') as Confirmacao;
	else
		 select concat('O código de FABRICAR informado não existe!') as Alerta;
	end if;
else
	select concat('O código de MATÉRIA-PRIMA informado não existe!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirMateriaPrimaFabricar (10, 1, 1);
select * from MateriaPrimaFabricar;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA PEDIDO:

delimiter $$ 
create procedure InserirPedido(status_ped varchar(200), praso_entr date, data_ped date, nome_cli varchar(200), nome_func varchar (200), descricao varchar(200),
 qtd_itens int, codigo_do_cliente int, cod_do_funcionario int, codigo_do_produto int)
begin
if(qtd_itens > 0) then
	if(nome_cli is not null) then 
		insert into Pedido values (null, status_ped, praso_entr, data_ped, nome_cli, nome_func, descricao, qtd_itens, codigo_do_cliente, cod_do_funcionario, codigo_do_produto);
        select concat('Pedido inserido com sucesso!') as Confirmacao;
	
    else
		select concat('Insira o nome do cliente!') Alerta;
        
	end if;
    
else
	select concat('A quantidade de itens tem que ser maior que 0!') as Alerta;

end if;

end;

$$ delimiter ; 
call InserirPedido('em andamento', '2021-08-30', '2021-09-10', 'Fernando', 'Viny', 'Convite de casamento', 20, 1, 1, 1);
select * from Pedido;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA VENDA: 

delimiter $$
create procedure InserirVenda (unidade varchar(200), valorDesc double, data date, valorUnid double, formaPag varchar(200), nomeCli varchar(200), nomeVend varchar(200), descricao varchar(300), quantidade int, valorTotal double, pedido int, cliente int, funcionario int, caixa int, produto int)
begin
declare verificafunc int;
declare verificacliente int;
set verificafunc = (select cod_func from Funcionario where (cod_func = funcionario));
set verificacliente = (select cod_clien from Cliente where (cod_clien = cliente));

if (verificafunc is not null) then
	if (verificacliente is not null) then
		insert into Venda values (null, unidade, valorDesc, data, valorUnid, formaPag, nomeCli, nomeVend , descricao , quantidade , valorTotal , pedido , cliente , funcionario , caixa , produto);
        select concat('Venda registrada com sucesso!') as Confirmacao;
	else
		select concat('Não existe um CLIENTE com o código informado!') as Alerta;
	end if;
else
    select concat('Não existe um FUNCIONÁRIO com o código informado!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirVenda ('Caixa', 5.00, '2021-08-16', 3.00, 'à vista', 'João', 'Viny', 'Caixa para casamento 25x25cm', 10, 25.00, 1, 1, 1, 1, 1);
select * from Venda;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA VendaProduto:

delimiter $$
create procedure InserirVendaProduto (refer_produto int, refer_venda int)
begin 
declare verificaProduto int;
declare verificaVenda int;
set verificaProduto = (select cod_produto from Produto where (cod_produto = refer_produto));
set verificaVenda = (select cod_venda from Venda where (cod_venda = refer_venda));

if (verificaProduto is not null) then
	if (verificaVenda is not null) then
		insert into VendaProduto values (null, refer_produto, refer_venda);
        select concat('VendaProduto registrado com sucesso!') as Confirmacao;
	else
		select concat('Não existe uma VENDA com o código informado!') as Alerta;
	end if;
else
    select concat('Não existe um PRODUTO com o código informado!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirVendaProduto (1, 1);
select * from produto; 

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA PedidoVenda:

delimiter $$
create procedure InserirPedidoVenda (refer_pedido int, refer_venda int)
begin
declare verificaPedido int;
declare verificaVenda int;
set verificaPedido = (select cod_pedido from Pedido where (cod_pedido = refer_pedido));
set verificaVenda = (select cod_venda from Venda where (cod_venda = refer_venda));

if (verificaPedido is not null) then
	if (verificaVenda is not null) then
		insert into PedidoVenda values (null, refer_pedido, refer_venda);
        select concat('PedidoVenda registrado com sucesso!') as Confirmacao;
	else
		select concat('Não existe uma VENDA com o código informado!') as Alerta;
	end if;
else
	select concat('Não existe um PEDIDO com o código informado!') as Alerta;
end if;
end;
$$ delimiter ;
call InserirPedidoVenda (1, 1);
select * from PedidoVenda;

############################################################################################################################################################################################

#PROCEDIMENTO DA TABELA LOGIN:

delimiter $$
create procedure RegistrarLogin (nomeLog varchar(200), senhaLog varchar(200), funcionario int)
begin
declare verificanome varchar(200);
declare verificafuncio int;
set verificanome = (select nome from login where (nome = nomeLog));
set verificafuncio = (select cod_func from Funcionario where (cod_func = funcionario));

if (verificanome is null) then
	if (verificafuncio is not null) then
		insert into login values (null, nomeLog, senhaLog, funcionario);
        select concat('Usuário Registrado com Sucesso!') as Confirmacao;
	else
		select concat('O funcionário a que este login se refere não existe!') as Alerta;
    end if;
else
	select concat('Este nome de usuário já está sendo usado!') as Alerta;
end if;
end;
$$ delimiter ;
call RegistrarLogin ('Gabriel Estevam', '12345678', '2');
select * from login;
