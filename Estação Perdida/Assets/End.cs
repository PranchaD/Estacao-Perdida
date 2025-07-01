using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject _playerCutscene;
    public GameObject _monsterCutscene;
    public AudioClip screamer;
    public bool cutsceneMode;
    public int Timer;

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            GameObject enemy = GameObject.FindWithTag("Enemy");
            if(enemy != null)
                Destroy(enemy);

            _playerCutscene.SetActive(true);
            _playerCutscene.transform.position = transform.position;
            _playerCutscene.transform.rotation = new Quaternion(0, 180, 0, other.transform.rotation.w);
            cutsceneMode = true;
            Destroy(other.gameObject);
        }
    }

    void FixedUpdate() {
        if(cutsceneMode) {
            CutsceneHandle();
        }
    }

    void CutsceneHandle() {
        int _time = 0;
        int _duration = 5;

        if (DurationCheck(_time, _duration)) {
            _playerCutscene.transform.position = new Vector3(_playerCutscene.transform.position.x, _playerCutscene.transform.position.y, _playerCutscene.transform.position.z - 0.1f);
        }

        _time += _duration;
        
        _duration = 40;

        if (DurationCheck(_time, _duration)) {
            _monsterCutscene.SetActive(true);
            _playerCutscene.transform.position = new Vector3(_playerCutscene.transform.position.x, _playerCutscene.transform.position.y, _playerCutscene.transform.position.z - 0.1f);
        }

        _time += _duration;

        _duration = 60;

        if (DurationCheck(_time, _duration)) {
            _playerCutscene.transform.Rotate(0.0f, 3f, 0.0f, Space.World);
        }

        _time += _duration;

        _duration = 60;

        _time += _duration;

        _duration = 2;

        if (DurationCheck(_time, _duration)) {
            _monsterCutscene.GetComponent<AudioSource>().resource = screamer;
            _monsterCutscene.GetComponent<AudioSource>().Play();
        }

        _time += _duration;

        _duration = 15;

        if (DurationCheck(_time, _duration)) {
            _monsterCutscene.transform.position = new Vector3(_monsterCutscene.transform.position.x, _monsterCutscene.transform.position.y, _monsterCutscene.transform.position.z - 0.5f);
        }

        _time += _duration;

        _duration = 4;

        if (DurationCheck(_time, _duration)) {
            SceneManager.LoadSceneAsync(1);
        }

        Timer++;
    }

    bool DurationCheck(int _time, int _duration) {
        return (Timer > _time && Timer < _time + _duration);
    }
}
