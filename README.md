# 💎 Sistema Degazin

Sistema desktop desenvolvido para auxiliar na gestão de uma empresa de revenda de semijoias, centralizando processos de estoque, atendimentos, vendas, devoluções e geração de relatórios.

O projeto foi desenvolvido com foco em **organização, automação de processos e redução do esforço operacional**, transformando tarefas manuais em um fluxo integrado através de software.

---

## 📌 Sobre o projeto

O **Degazin** é um sistema desenvolvido para atender às necessidades de uma operação de revenda de semijoias.

Entre suas principais funções estão:

* 📦 Gerenciamento de peças e estoque
* 🧾 Registro e acompanhamento de atendimentos
* 💰 Controle de peças vendidas e devolvidas
* 📊 Cálculo de valores e saldos
* 📑 Geração de planilhas de atendimento
* 📧 Envio de mensagens por e-mail
* 🔐 Autenticação e armazenamento seguro de senhas
* 🖨️ Impressão de documentos e relatórios

O sistema utiliza um banco de dados MySQL para armazenar e consultar as informações necessárias para o funcionamento da aplicação.

---

## 🛠️ Tecnologias utilizadas

| Tecnologia         | Utilização              |
| ------------------ | ----------------------- |
| **C#**             | Linguagem principal     |
| **.NET Framework** | Plataforma da aplicação |
| **Windows Forms**  | Interface gráfica       |
| **MySQL**          | Banco de dados          |
| **MySql.Data**     | Comunicação com o MySQL |
| **BCrypt**         | Hash de senhas          |
| **MiniExcel**      | Geração de planilhas    |
| **SMTP**           | Envio de e-mails        |

---

## 🏗️ Estrutura

O projeto possui diferentes classes responsáveis por separar as principais responsabilidades do sistema.

### `BancoDeDados`

Responsável pela comunicação com o banco de dados MySQL, incluindo:

* abertura de conexões;
* consultas `SELECT`;
* operações `INSERT`;
* operações `UPDATE`;
* operações `DELETE`;
* execução de comandos parametrizados.

### `Seguranca`

Concentra funcionalidades relacionadas à segurança, incluindo:

* geração de hash de senhas utilizando BCrypt;
* verificação de senhas;
* validação de endereços de e-mail.

### `Utilitarios`

Reúne funcionalidades auxiliares utilizadas pelo sistema, como:

* envio de e-mails;
* envio de e-mails com anexos;
* impressão de arquivos;
* geração de planilhas de atendimento.

---

## 📊 Geração de planilhas

O sistema consegue gerar planilhas de atendimento contendo informações como:

* identificação das peças;
* código original;
* descrição;
* preço;
* situação da peça;
* quantidade total de peças;
* quantidade de peças vendidas;
* montante vendido;
* dívida referente ao atendimento;
* saldo acumulado.

As planilhas são geradas utilizando **MiniExcel** a partir de um modelo previamente definido.

---

## 🔐 Segurança

Este repositório **não contém credenciais reais de acesso ao sistema**.

Informações sensíveis, como:

* senhas;
* credenciais de banco de dados;
* credenciais de e-mail;
* configurações de produção;
* dados reais de clientes e revendedoras;

devem permanecer fora do controle de versão.

Para configurar uma instalação local, utilize o arquivo de exemplo de configuração fornecido no projeto e informe suas próprias credenciais.

> ⚠️ Nunca publique senhas, tokens, chaves de API ou credenciais de banco de dados no GitHub.

---

## 🗄️ Banco de dados

O sistema utiliza **MySQL** como banco de dados.

Por questões de segurança e privacidade, este repositório não disponibiliza o banco de produção nem dados reais utilizados pelo sistema.

Caso uma estrutura de banco de dados seja disponibilizada futuramente, ela deverá conter apenas dados fictícios ou estrutura suficiente para execução do projeto em ambiente de desenvolvimento.

---

## 🖥️ Interface

> Imagens e demonstrações do sistema serão adicionadas ao repositório conforme o projeto for documentado.

---

## 🚀 Objetivos do projeto

O Degazin nasceu de uma necessidade prática: transformar processos que dependiam de controles manuais em uma aplicação capaz de centralizar informações e automatizar tarefas.

O projeto também serve como experiência prática no desenvolvimento de software, envolvendo conceitos como:

* programação orientada a objetos;
* acesso a bancos de dados;
* SQL;
* segurança de senhas;
* manipulação de arquivos;
* geração de documentos;
* comunicação por e-mail;
* desenvolvimento de interfaces gráficas;
* organização de código.

---

## 📚 Status

🚧 **Em desenvolvimento**

O sistema continua recebendo melhorias, correções e novas funcionalidades.

---

## 👨‍💻 Autor

**Nicolas da Silva Valadares**

Projeto desenvolvido como aplicação prática de desenvolvimento de software e automação de processos.

---

## ⚖️ Observação

Este repositório tem finalidade **educacional e de portfólio**.

O código disponibilizado publicamente pode não representar integralmente a versão utilizada em produção. Informações, credenciais, dados pessoais e demais elementos sensíveis foram deliberadamente omitidos.

---

⭐ Se este projeto foi útil ou interessante para você, considere deixar uma estrela no repositório!
