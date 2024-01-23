# Inteli - Instituto de Tecnologia e Liderança 

<p align="center">
<a href= "https://www.inteli.edu.br/"><img src="./document/outros/assets/imagens/inteli.png" alt="Inteli - Instituto de Tecnologia e Liderança" border="0" width=40% height=40%></a>
</p>

<br>

# IoTrack

## ECOTVOS

## 👨‍🎓 Integrantes: 
- <a href="https://www.linkedin.com/in/bianca-borges-969586206/">Bianca Borges Lins</a>
- <a href="https://www.linkedin.com/in/breno-santana-4a1912228/">Breno Santana</a> 
- <a href="https://www.linkedin.com/in/filipe-calabro-3b3517243/">Filipe Calabro</a> 
- <a href="https://www.linkedin.com/in/gabrielle-mitoso-6253a219b/">Gabrielle Mitoso</a>
- <a href="https://www.linkedin.com/in/hugo-noyma/">Hugo Noyma</a>
- <a href="https://www.linkedin.com/in/lucas-nogueira-nunes/">Lucas Nogueira Nunes</a> 
- <a href="https://www.linkedin.com/in/pedro-auler-a3b23021a/">Pedro Auler</a>

## 👩‍🏫 Professores:

### Orientador(a) 

- <a href="https://www.linkedin.com/in/marcelo-gon%C3%A7alves-phd-a550652/">Marcelo Gonçalves</a>

### Instrutores

- <a href="https://www.linkedin.com/in/andreluizbraga/">André Luiz Braga</a>
- <a href="https://www.linkedin.com/in/bruna-mayer-00a556174/">Bruna Mayer</a>
- <a href="https://www.linkedin.com/in/profclaudioandre//">Cláudio André</a>
- <a href="https://www.linkedin.com/in/cristiano-benites-687647a8/">Cristiano da Silva Benites</a>
- <a href="https://www.linkedin.com/in/fatima-toledo/">Fatima Toledo</a> 
- <a href="https://www.linkedin.com/in/henrique-mohallem-paiva-6854b460/">Henrique Paiva</a> 
- <a href="https://www.linkedin.com/in/juliastateri/">Julia Stateri</a>
- <a href="https://www.linkedin.com/in/laizaribeiro/">Laíza Ribeiro</a>
- <a href="https://www.linkedin.com/in/sergio-venancio-a509b342/">Sergio Venancio</a> 
- <a href="https://www.linkedin.com/in/tatiane-gandra/">Tatiane Azevedo Gandra</a>

## 📜 Descrição

O IoTrack é uma solução tecnológica que utiliza IoT (Internet of Things ou Internet das Coisas) para realizar o monitoramento de ativos da empresa Atvos, grande produtora brasileira de biocombustíveis e parceira deste projeto. Essa temática IoT diz respeito a dispositivos de integração entre objetos físicos de tecnologia com funcionalidades específicas, conhecidos como "hardwares", e sistemas programados por desenvolvedores para explorar as possibilidades propiciadas pelos hardwares, denominados "softwares", por meio de protocolos de comunicação conectados à internet (por isso o nome "internet das coisas").

A solução foi idealizada e construída por estudantes do Instituto de Tecnologia e Liderança - Inteli do grupo ECOTVOS como projeto de quarto (e último) módulo do primeiro ano da faculdade, a partir das problemáticas trazidas pela Atvos. Elas consistiam principalmente da falta de controle de estoque no transporte de peças e insumos entre as áres de almoxarifado e da lavoura, além do registro manual de saída e entrada de materiais do estoque e dos caminhões oficina, veículos que circulam pelas unidades para atender a necessidades de consertos e reparos dos equipamentos rodantes (tratores, colhedores de cana, caminhões, entre outros). Ademais, a empresa relatou ocorrências de desvio e roubo desses ativos, facilitadas pelo sistema arcaico empregado na administração dos mesmos.

Dessa forma, observou-se os prejuízos produtivos e econômicos decorrentes da ausência de otimização de processos e de implementação de tecnologia tanto para segurança da empresa quanto para automatização ou agilização de tarefas dispendiosas. Logo, fez-se necessária uma solução que agregasse funcionalidades dedicadas à prevenção, ao aprimoramento da segurança e da eficiência operacional da Atvos, permitindo um melhor gerenciamento de seus ativos, e esse foi o trabalho que o grupo ECOTVOS buscou realizar.

A fim de cumprir com os objetivos supracitados, arquitetou-se uma solução baseada principalmente no uso de leitores de etiquetas RFID (Radio Frequency Identification) para monitoramento do fluxo de movimentações dos ativos da empresa, incluindo processos de transporte de cargas e manutenções, principais pontos focais da solução. Além disso, o projeto conta com uma plataforma web estruturada que permite o monitoramento digital e em tempo real dos processos mencionados. Assim, procurou-se aprimorar a segurança e otimizar a logística da empresa com o emprego da tecnologia IoT.

Para aprofundamento nos detalhes da solução, recomenda-se a consulta à [documentação](./document/documentacao.md) do projeto. O funcionamento do mesmo pode ser rapidamente visualizado no [vídeo demonstrativo do projeto](https://drive.google.com/file/d/1xOyeAJW6j99VSKOepSae6sd6h-6Bt2mJ/view?usp=sharing).

## 📁 Estrutura de pastas

Dentre os arquivos e pastas presentes na raiz do projeto, definem-se:

- <b>document</b>: aqui estão todos os documentos do projeto, incluindo o manual de instruções. Há também uma pasta denominada <b>outros</b> onde estão presentes outros documentos complementares.

- <b>src</b>: Todo o código fonte criado para o desenvolvimento do projeto, incluindo firmware, notebooks, backend e frontend.

- <b>README.md</b>: arquivo que serve como guia e explicação geral sobre o projeto (o mesmo que você está lendo agora).

## 🔧 Instalação

Os softwares e serviços que precisam ser instalados para utilização e customização do projeto são listados a seguir com seus respectivos links para download:

- Node.js: <<https://nodejs.org/en/download>>. Utilizado para executar o frontend.

- Visual Studio Code: <<https://code.visualstudio.com/download>>. Necessário para configuração e execução do firmware.

- Visual Studio: <<https://visualstudio.microsoft.com/pt-br/downloads/>>. Utilizado no backend.

- Instalação do driver .NET: <<https://dotnet.microsoft.com/pt-br/download/dotnet>>. Necessário para execução do backend.

- Comandos de instalação do driver .NET: <<https://learn.microsoft.com/pt-br/dotnet/core/install/windows?tabs=net80>>. Necessário para execução do backend.

Os processos de instalação e instruções mais detalhadas podem ser encontradas no [Manual de Instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf) do projeto, especifcamente na seção "Guia de Instalação". Recomenda-se a leitura e a execução atenciosa dos passos indicados nos assistentes de instalação.

## ✅ Execução

### Frontend

Para execução do frontend da solução, os seguintes passos devem ser seguidos:

#### 1. Dirigir-se ao diretório "frontend":
Primeiro, é necessário se dirigir ao diretório frontend em um terminal, no caminho "(root)/src/frontend" (root é o diretório raiz do projeto).

#### 2. Instalar as dependências:
Depois, é preciso instalar as dependências utilizadas no frontend. Para isso, executa-se o comando "npm install" no diretório frontend no terminal (instruções para isso podem ser encontradas também no [manual de instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf)).

#### 3. Executar:
Por fim, executa-se o comando "npm start" no terminal após a instalação das dependências ser concluída. Então, será executado o frontend.

### Backend

Para execução do backend da solução, os seguintes passos devem ser seguidos:

#### 1. Dirigir-se ao diretório "backend":
Primeiro, é necessário se dirigir ao diretório "backend" em um terminal, no caminho "(root)/src/backend", que contém o projeto em .NET a ser executado.

#### 2. Executar:
Com o driver .NET instalado (consultar o [manual de instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf)), executa-se o comando "dotnet run" no diretório especificado anteriormente. Assim, o backend será executado.

### Firmware

Para execução do firmware da solução, recomenda-se seguir as orientações presentes no guia de instalação e no guia de configuração do [manual de instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf), que consistem em:

#### 1. Instalar o [Platform.IO](https://platformio.org):
Primeiro, é necessário instalar a extensão [Platform.IO](https://platformio.org) do Visual Studio Code.

#### 2. Configurar a rede utilizada:
Depois, é preciso configurar a rede utilizada editando o arquivo "connectionData.hpp" da solução (instruções para isso podem ser encontradas também no [manual de instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf)).

#### 3. Upload do código:
Por fim, faz-se o upload do código para o microcontrolador através da extensão [Platform.IO](https://platformio.org) (instruções para isso podem ser encontradas também no [manual de instruções](./document/Manual%20de%20Instruções%20ECOTVOS.pdf)). Após a conclusão, o microcontrolador estará pronto para ser ligado e imediatamente utilizado.

## 🗃 Histórico de lançamentos

* 0.5.0 - 20/12/2023
    * Documentação da arquitetura e o protótipo final da solução;
    * Revisão geral da documentação e dos códigos;
    * Finalização do frontend e do protótipo físico.
* 0.4.0 - 11/12/2023
    * Documentação da arquitetura do protótipo e de orientações para descarte de materiais;
    * Construção do manual de instruções;
    * Projeção inicial da case para o protótipo físico;
    * Avanços na programação do protótipo físico e no frontend.
* 0.3.0 - 27/11/2023
    * Documentação da arquitetura da solução e da metodologia utilizada;
    * Início do frontend;
    * Comunicação do protótipo físico via MQTT.
* 0.2.0 - 10/11/2023
    * Backend do projeto;
    * Projeção inicial das telas do frontend;
    * Conexão do protótipo físico com rede WiFi.
* 0.1.0 - 30/10/2023
    * Documentação do entendimento do projeto e seu usuário;
    * Análise de negócios;
    * Política de privacidade;
    * Prototipação inicial.

## 📋 Licença/License

<p xmlns:cc="http://creativecommons.org/ns#" xmlns:dct="http://purl.org/dc/terms/"><a property="dct:title" rel="cc:attributionURL" href="https://github.com/2023M4T10Inteli/grupo2">IOTrack</a> by <a rel="cc:attributionURL dct:creator" property="cc:attributionName" href="https://github.com/2023M2T6-Inteli/Projeto3">INTELI, BIANCA BORGES, BRENO SANTANA, FILIPE CALABRO, GABRIELLE MITOSO, HUGO NOYMA, LUCAS NUNES, PEDRO AULER</a> is licensed under <a href="http://creativecommons.org/licenses/by/4.0/?ref=chooser-v1" target="_blank" rel="license noopener noreferrer" style="display:inline-block;">Attribution 4.0 International<img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/cc.svg?ref=chooser-v1"><img style="height:22px!important;margin-left:3px;vertical-align:text-bottom;" src="https://mirrors.creativecommons.org/presskit/icons/by.svg?ref=chooser-v1"></a></p>
