using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;

    void Update()
    {
        //왼쪽 마우스 클릭
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        //총알 생성하기
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        //총알 발사하기
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //일정 시간이 지나면 총알 삭제
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }    
}
