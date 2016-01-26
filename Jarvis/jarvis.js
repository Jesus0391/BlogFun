/// <reference path="C:\Users\Jesus\Documents\Visual Studio 2013\Projects\E.G.O.I.S.T\Jarvis\annyang.js" />
// JavaScript source code
$(function () {
    if (annyang) {
        //annyang.addCommands({
        //    'Sam *': function (userSaid, commandText, phrases) {
        //        console.log(userSaid);
        //        console.log(commandText);
        //        console.log(phrases);
        //    }
        //});

        annyang.addCommands({
            'buen dia sam': function () {
                console.log("prueba");
                responsiveVoice.speak("Buenos Dias Sr.", "Spanish Female");
            }
        });
        annyang.setLanguage('es-Do');
        // Start listening.
        annyang.start();
    }
});

//Posibles commando de voz que se pueden configurar a distintas respuestas basandose en comportamientos example:

/*
   *greeting* Sam como esta todo?
   "Buenos Dias", "Buenas tardes", "buenas Noches" (saludos de cortesia que deben ser respondido

*/