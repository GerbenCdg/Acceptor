# Acceptor

https://opale.u-clermont1.fr/info/wiki/doku.php?id=etud:info:jurodrigue:objet2:tp-2

<align center>
<uml>
skinparam classAttributeIconSize 0
hide circle
Acceptor "1" *-- "1" Validator : " #validator"
Acceptor "1" *-- "6" Pipe: " -pipes[]"
Acceptor "1" *-- "1" RejectPipe: " -rejectPipe"
Acceptor "1" *-- "1" Box: " -box"
Acceptor "1" *-- "1" Display: " -display"
Box "1" o-- "*" Coin: "-coins"
Pipe "100" o--- "1" Coin: "-coins"
Selector "1" o-- "1" Acceptor : -acceptor


class Acceptor {

-selectedProductPrice : int
#IsPurchaseFinished : bool
+InsertCoins(coins:Coin[]) : void
#InsertInRejectPipe(c:Coin) : void
+GetState() : void
#SelectProduct(price:int): void
#CheckInsertedMoney(): void
+GetRefund() : void
#Confirm() : void
+MaintenanceCheck() : void
-CanGiveChange(quantityToGive:int) : bool
#GiveChange(amount:int) : void
-GetValuesInsidePipes() : void

}

class Box{
-{STATIC}MAX-CAPACITY = 500 : int
-coins:List<Coin>
#AddCoin(Coin c) : void
+ToString() : string
}

enum Coin{
e2 = 200, e1 = 100, c50=50, c20 = 20, c10 = 10, c5 = 5
}

class Display{
#DisplayMessage(msg:string) : void
#{STATIC}DisplayAsPrice(priceInCents) : string
}

class Pipe{
-{STATIC} MAX-CAPACITY = 100 : int
#NumberOfCoins : int
#coins : Coin[]
#CoinType : Coin
#IsFull() : bool
#Clear() : int
#AddCoin(c:Coin) : void
#GiveCoins(quantity:int) : Coin[]
+ToString() : string
}

class RejectPipe{
-coins : List<Coin>
#AddCoins(coins:Coin[]) : void
#AddCoin(Coin c) : void
+GetState() : void
+WithDrawCoins() : void
}


class Selector {
SelectProduct(price:float) : void
+Buy(price : float) : void
}

class Validator{
-acceptor : Acceptor
#ValidatorCoins : List<Coin>
+InsertCoins(coins:Coin[]) : void
+InsertCoin(coin:Coin) : void
#ValidateCoin(coin:Coin) : bool
#GetCoinsValue() : int
- IsValid() : bool
}


</uml>
</align>
