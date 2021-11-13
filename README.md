# HackPleasanterApi.Csharp

## これは何?

Pleasanter APIをC#で呼び出すためのライブラリとなります。
HackPleasanterApiCliコマンドを使用することで、プリザンターのサイトパッケージからグルーコードを生成してこのライブラリと結合してプリザンターAPIを呼び出すことができます。

[HackPleasanterApiCli](https://github.com/yamada28go/HackPleasanterApiCli)

## ディレクトリ構成

| No | ディレクトリ名  | 概要  |
| --- | --- | --- |
| 1 | Src  |  ライブラリコードの本体が格納されています。 |
| 2 |  Templates | [HackPleasanterApiCli](https://github.com/yamada28go/HackPleasanterApiCli)でグルーコードを生成するときに使用するテンプレートが格納されています。 |


## 使い方

### 1: グルーコードを生成

Pleasanterのサイトパッケージ(JSON)をエクスポートとして、グルーコード生成対象となるテーブル、インターフェースを決定します。

これらの動作の詳細は以下コマンドを参照してください。

[HackPleasanterApiCli](https://github.com/yamada28go/HackPleasanterApiCli)

### 2: ライブラリのリンク

本ライブラリをリンクして使用してください。
本ライブラリの詳細な使用方法は添付のテストコートを参照してください。

## 対応API

本ライブラリはすべてのAPIに対応指定するわけではありません。
対応しているAPIは以下となります。

| No | API種別 | 
| --- | --- | 
| 1 |単一レコード取得| 
| 2 |複数レコード取得|
| 3 |レコード作成 |
| 4 |レコード更新|
| 5 |レコード削除|
| 6 |レコード一括削除|
| 7 |添付ファイル取得|