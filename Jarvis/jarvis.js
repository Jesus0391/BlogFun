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
        annyang.debug();
        annyang.addCommands({
            'Inori': function () {
                alert("Buenos Dias");
                responsiveVoice.speak("Buenos Dias Sr.", "Spanish Female");
            },
            'Nuevo Post *post': function (post) {
                $("input[name='Title']").val(post);
                $("#saveHistory").click();
            },
            'muestrame a *name': function (name) {
                var i = 0;
                $(".card-image-headline").each(function () {
                    if (name == $(this).text().trim()) {
                        $($(".btn-raised")[i+1])[0].click();
                    }
                    i++;
                });
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