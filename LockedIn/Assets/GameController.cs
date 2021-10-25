using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool selectedPortuguese = true;
    List<Line> interactionLines = new List<Line>();

    string[] availableLanguages = { "english", "portuguese" };
    List<Tuple<string, string[]>> availableLanguagesLines = new List<Tuple<string, string[]>>();

    [SerializeField] GameObject winScreen;

    string[] englishLines =
    {
        "It's locked.",
        "It's still locked.",
        "I don't have the key.",
        "This is heavy.",
        "Sometimes I put my keys over here. Let me check...",
        "Let me check under it.",
        "Oh, I found a number!",
        "Maybe I dropped it on the couch.",
        "Let me check the drawer.",
        "This painting is crooked. Oh, I forgot about the safe.",
        "What is the password now?!",
        "I can't remember the password. I know I wrote it somewhere!",
        "Maybe there is something behind the vase.",
        "Am I going crazy? Well, better safe than sorry! Let me check the vent...",
        "I can't believe I've found a number! This place is kind of a mess.",
        "Hold on! There is a number by the safe! ",
        "Better remember this number.",
        "No way I'm calling Alice again! She always says I can't find anything. Well...",
        "That's too high. I need something to help me reach it. ",
        "Yeah, that's it! A number!",
        "This is the fourth vase we bought. Hope we don't break this one.",
        "This cabinet was given by my mother on our third anniversary.",
        "We bought this painting on our second trip together. ",
        "This couch was the first furniture we bought for the house.",
        "Finally It's open!",
        "Oh yeah! Here's the key!",
        "Nice! Now...where is my wallet?!",
        "I already found a number here.",
        "I already found a up number there",
        "I've already written this down.",
        "I still can't belive there was a note there."
    };

    string[] portugueseLines =
    {
        "Está trancada.",
        "Ainda está trancada.",
        "Eu não estou com a chave.",
        "Que mesa pesada.",
        "Às vezes eu deixo minhas chaves aqui. Deixa eu dar uma olhada...",
        "Deixa eu ver aqui embaixo.",
        "Ah, achei um número!",
        "Pode ser que eu tenha derrubado no sofá.",
        "Deixa eu ver na gaveta.",
        "Esse quadro está torto. Ah, tinha esquecido do cofre.",
        "Qual é a senha mesmo?",
        "Eu não lembro a senha. Sei que anotei em algum lugar!",
        "Talvez tenha algo atras do vaso.",
        "Eu estou ficando louco? Bom, já que estou aqui! Deixa eu ver na ventilação.",
        "Não acredito que achei um número! Essa sala está uma bagunça.",
        "Pera aí! Tem um número na parede!",
        "Melhor decorar esse número.",
        "Nem a pau vou ligar para a Alice de novo! Ela sempre diz que não acho nada em casa. Bem...",
        "Isso está muito alto. Preciso de alguma coisa que me ajude a alcançar.",
        "Isso! Encontrei um número!",
        "Essa é o quarto vaso que compramos. Espero que não quebremos esse.",
        "Minha mãe deu esse gabinete no nosso terceiro aniversário de casamento. ",
        "Nós compramos esse quadro na nossa segunda viagem juntos.",
        "O sofá foi o primeiro móvel que compramos para a casa.",
        "Finalmente consegui abrir!",
        "Isso! Achei a chave!",
        "Ótimo! Agora...cadê a minha carteira?!",
        "Já achei um número aqui.",
        "Já achei um número aqui em cima.",
        "Já anotei esse número.",
        "Ainda não acredito que tinha uma nota ali..."
    };

    string[] objectsOfInteraction =
    {
        "door",
        "door",
        "door",
        "table",
        "bookshelf",
        "underbookshelf",
        "underbookshelf",
        "couch",
        "cabinet",
        "paintingbig",
        "safe",
        "safe",
        "vaselarge",
        "vent",
        "vent",
        "lightswitch",
        "numberonthewall",
        "phone",
        "topshelf",
        "topshelf",
        "vasesmall",
        "cabinet",
        "paintingsmall",
        "couch",
        "safe",
        "safe",
        "door",
        "underbookshelf",
        "topshelf",
        "numberonthewall",
        "vent"
    };

    int[] references =
    {
        -1,
        1,
        2,
        18,
        -1,
        -1,
        5,
        -1,
        -1,
        -1,
        9,
        10,
        -1,
        -1,
        13,
        -1,
        15,
        -1,
        -1,
        3,
        -1,
        -1,
        -1,
        -1,
        -99,
        24,
        25,
        6,
        19,
        16,
        14
    };

    int foundNotesCount = 0;
    [SerializeField] List<GameObject> notes;

    void Awake()
    {
        availableLanguagesLines.Add(new Tuple<string, string[]>(availableLanguages[0], englishLines));
        availableLanguagesLines.Add(new Tuple<string, string[]>(availableLanguages[1], portugueseLines));

        selectedPortuguese = Application.systemLanguage == SystemLanguage.Portuguese;

         string[] selectedLanguage = selectedPortuguese ? availableLanguagesLines[1].Item2 : availableLanguagesLines[0].Item2;

        for (int i = 0; i < selectedLanguage.Length; i++)
        {
            Line line = new Line(selectedLanguage[i], objectsOfInteraction[i], references[i], i);
            if (line.id == 6 || line.id == 14 || line.id == 16 || line.id == 19)
            {
                line.callback = FoundNote;
            }
            if (line.id == 26)
                line.callback = OpenedDoor;

            interactionLines.Add(line);
        }

        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        // iterate root objects and do something
        for (int i = 0; i < rootObjects.Count; ++i)
        {
            GameObject gameObject = rootObjects[i];
            foreach (Line line in interactionLines)
            {
                if (gameObject.name.ToLowerInvariant().Equals(line.objectOfInteraction))
                {
                    gameObject.GetComponent<Interaction>().lines.Add(line);
                }
            }
        }
    }

    public bool HasLineBeenRead(int id)
    {
        if (id == -99)
        {
            return foundNotesCount == 3;
        }

        return interactionLines[id].hasBeenRead;
    }

    public void AddCallback(int id, Action callback)
    {
        interactionLines[id].callback = callback;
    }

    public void FoundNote()
    {
        foreach (GameObject note in notes)
        {
            if (!note.active)
            {
                note.SetActive(true);
                break;
            }
        }
        foundNotesCount += 1;

        if (foundNotesCount == 3)
        {
            interactionLines[0].hasBeenRead = true;
            interactionLines[1].hasBeenRead = true;
            interactionLines[2].hasBeenRead = true;
            interactionLines[10].hasBeenRead = true;
            interactionLines[11].hasBeenRead = true;
        }
    }

    public void OpenedDoor()
    {
        StartCoroutine(OpenDoorAfterDelay());
    }

    IEnumerator OpenDoorAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        winScreen.SetActive(true);
    }
}
