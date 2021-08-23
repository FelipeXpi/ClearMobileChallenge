![logo](Resources/icon-menu.png) 

# Challenge Clear - Desenvolvedor Mobile
## Desafio Xamarin Forms

Nós 🥳, da Guilda Mobile da Clear Corretora sempre estamos em busca do melhor para nosso APP📱, hoje, feito em Xamarin Forms 💕. Não temos a melhor arquitetura, não temos o melhor código fonte, mas estamos em evolução 📈 constante para entregar o melhor para o nosso cliente 🥰. E dentre as estratégias, é reunir os melhores devs 💻 mobile que poderiamos ter. Por isso estamos lançando esse desafio para você 👊. 


O desafio é implementar um app 📱 onde o nosso cliente possa consultar suas ordens enviadas a bolsa de valores.📈

## Features
- Criar uma página de login
- Criar uma página com uma lista de ordens 
- Consumir uma API REST com a lista de ordens
- Sistema de navegação entre as páginas

## Avaliação
 Tudo é permitido, pense como se esse APP fosse seu, você é o dono do negócio. Nossa avaliação será em cima de como você lidará com essa demanda; performance, tratamento de erros, layout. Questões de arquitetura, estrutura, plugins e code-smell também serão avaliados.
 
## Protótipo

| ![Page1](Resources/Tela-Login.jpg)  | ![Page2](Resources/Tela-Ordens.jpg) |
|:---:|:---:|
| Login | Listagem de Ordens |


### Algumas especificações

- Distâncias entre Margens não é importante. (Queremos testar a sua percepção)
- Tipo da fonte não é importante.
- Tamanho da fonte não é importante. (Queremos testar a sua percepção)

| Cores | hexadecimal |
| ------ | ------ |
| Badge (verde) Status: "Executada" | #7cd444 |
| Badge (cinza) tipo da ordem: "Swing T." | #4d677e |
| Badge (vermelho) "V" para quando for uma venda | #c2052b |
| Badge (azul) "C" para quando for uma compra | #052fff |
| Cor de Background  | #131a20 |
| Cor de Background do item da lista  | #1d262f |
| Cor botão do login  | #0404cf |

Link externo para "abra sua conta":
```sh
https://cadastro.clear.com.br/desktop/step/1
```

Logotipo da clear:
```sh
https://cadastro.clear.com.br/images/logos/clear-logo.png
```

Endpoint para API:
```sh
get: https://6123c2e6124d880017568476.mockapi.io/api/v1/swingtrade/orders
```

Exemplo modelo do item da lista JSON:
```sh
{
    "createdAt": "2021-08-23T09:21:44.521Z",
    "symbol": "ABEV3",
    "name": "AMBEV S/A ON",
    "quantity": "400",
    "type": "A Mercado",
    "side": "Compra",
    "module": "Swing Trade",
    "status": "Executada",
    "logo": "https://pro.clear.com.br/src/assets/symbols_icons/ABEV.png",
    "id": "1"
}
```

## Requisitos Essenciais

- [x] Siga o mínimo do modelo do protótipo
- [x] Usar Xamarin Forms > 5.0.0
- [x] Criar o layout com XAML
- [x] Projeto deve rodar no Android e iOS
- [x] Layout deve ser responsivo


## Bônus

- [ ] Testes de unidade
- [ ] Testes de interface (Xamarin UI)
- [ ] Documentação

## Observações

- Inclua todo seu código dentro do diretório /put-your-challenge-here
- Ao final do desenvolvimento, abra um Pull Request direcionada á branch que foi passada a você
- Leia com atenção a toda essa especificação, e nos diga a SUA estimativa de entrega em dias.

## Dicas 😘 
- TUDO a mais, será avaliado como bônus
- Componentização é importante para nós
- Um código C# bem escrito não quer guerra com ninguém
- Os componentes do Xamarin Forms são praticamente suficientes para o teste
- Pense como um projeto escalável
- Não use bala de canhão para matar uma formiga
