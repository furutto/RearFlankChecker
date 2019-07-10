# RearFlankChecker
FFXIV向けのACTプラグインです。

方向指定条件のあるスキル実行時にミスしたら、音で知らせたりミスしたスキルの情報を表示します。  
`
低レベル時、または低レベルにシンクされた状態だとチェックが正しく行われない場合があります。
最大レベルでのコンテンツで動作確認してます。
`
## ダウンロード
[リリースページ](https://github.com/furutto/RearFlankChecker/releases/latest)からダウンロード
## インストール
1. ダウンロードファイルを任意のディレクトリに展開 
1. resources フォルダをACT本体があるディレクトリかRearFlankChecker.dllと同じディレクトリに配置
1. RearFlankChecker.dll を ACT からプラグイン追加
#### 動作環境
* .NET Framework 4.7.1 以降
## 使用方法
![Config](https://github.com/furutto/RearFlankChecker/blob/master/resources/image/readme_config.jpg)
1. [Plugins]タブの[Rear And Flank Checker]タブに設定項目があります。
1. 方向指定ミス時に鳴らす効果音の設定
1. 方向指定ミスの情報を表示するビューアに関する設定
![Viewer](https://github.com/furutto/RearFlankChecker/blob/master/resources/image/readme_viewer.jpg)
1. ミスした場合にスキル名と回数を表示
## ライセンス
[三条項BSDライセンス](LICENSE)  
## 連絡先
twitter:  [@furutto_dev](https://twitter.com/furutto_dev)  