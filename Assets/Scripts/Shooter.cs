using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //マウスでクリックしたところからレイをだす
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit; //中身Null
            
            //参照渡し
            //outつけるとメソッドの中でhitに値をつけることを保証している
            //渡すときはNull　使うときは値が入っている
            //第三引数　光線１００ｍ　距離
            //第２引数コライダーがあればコライダーの住所が入る
            //RaycastHitは構造体（クラスのようなもの）でプロパティをもっていて、コライダーやポイントなどがある
            //そのNullのプロパティにメソッドの結果が入る　
            //Raycast戻り値はboolでtrue or false 
            //そこにモノがあってヒットしたらtrueを返して無かったらfalseを返す
            if(Physics.Raycast(ray, out hit, 100f))
                //Physicsクラスのメソッドを使用している
            {
                //hitのプロパティのゲームオブジェクト
                Destroy(hit.collider.gameObject);

                //参照渡しと参照値渡しは違う
                //Javaは参照値渡し
                //参照値渡し原本影響しないときとするときがある
                //参照渡し原本に影響する
            }
            /*貫通ビーム　拡張for文 
             ビームにあたった球たちがレイキャスト構造体の配列として返ってくる
             foreach(RaycastHit hit in Physics.RaycastAll(ray)) {
                Destroy(hit.collider.gameObject);
            デストロイは１個ずつしか消せないからfor文で消す
             }
            */

            /*もっとパワーのある光線　直径3mの球でレイを飛ばす
              foreach (RaycastHit hit in Physics.SphereCastAll(ray,3f)) {
               Destroy(hit.collider.gameObject);
              }
            */
        }
    }
}
