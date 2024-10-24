# led7x5_tm1637
TM1637を用いて表示している7x5ドットマトリックスLEDに5x7フォント文字を送信するWindowsプログラムと、受信するM5NanoC6のプログラムです。

## Windowsに「pixelfont-5x7.ttf」をインストールしてください。
　pixelfont-5x7.ttfは、ユズノカ様作成の mikannnoki-fontの1つです。以下のサイトよりダウンロードできます。

[https://mikannnoki-font.booth.pm/](https://mikannnoki-font.booth.pm/)

[https://booth.pm/ja/items/1477300](https://booth.pm/ja/items/1477300)

## PCからの送信データと受信して表示するLEDの7x5点灯の説明
7x5LEDの点灯パラメータとして、1列ごとに1文字の英数文字を割り付けています。

![7x5LED](https://github.com/tarosay/led7x5_tm1637/blob/main/7x5led.png)


列のLEDはビットで設定し、0が全消灯、31が全点灯となります。
この32パターンのビットを32個の英数文字に割り付けています。

{"0":"0", "1":"1", "2":"2", "3":"3", "4":"4", "5":"5", "6":"6", "7":"7",

 "8":"8", "9":"9","10":"a","11":"b","12":"c","13":"d","14":"e","15":"f",

"16":"g","17":"h","18":"i","19":"j","20":"k","21":"l","22":"m","23":"n",

"24":"o","25":"p","26":"q","27":"r","28":"s","29":"t","30":"u","31":"v"}


例えば、「マ」という文字は、"1599lj0"という文字列を、7文字ずつ順番に送信します。

![マ](https://github.com/tarosay/led7x5_tm1637/blob/main/ma.png)

0000001 → 送信

0000015 → 送信

0000159 → 送信

0001599 → 送信

001599l → 送信

01599lj → 送信

1599lj0 → 送信

こんな感じです。

## Windowsアプリの使い方
Windowsプログラム7x5dotFontSenderのC#のソースもあります。exeフォルダに実行ファイルも入っています。

上に書いたように、pixelfont-5x7.ttfをインストールしてください。

7x5dotFontSenderを起動後、シリアルポートを選択して接続してください。

![Serial](https://github.com/tarosay/led7x5_tm1637/blob/main/SelectSerialPort.png)

送信欄に書いた文章を1行ずつ、上記のようなビット変換をしてシリアルポートから出力します。

送信速度は変更可能です。

![Serial](https://github.com/tarosay/led7x5_tm1637/blob/main/7x5dotFontSender.png)

以上
