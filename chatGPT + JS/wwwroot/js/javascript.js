const baseUrl = "https://localhost:7036/api/"

async function getQuestion() {

//נשלוף ונשמור את הערך מתיבת הטקסט במשתנה
    const subject = document.getElementById("promptSubject").value;
    const charecter = document.getElementById("promptcharecter").value;
    const language = document.getElementById("promptLanguage").value;
    const level = document.getElementById("promptLevel").value;
    const prompt = {
        "Subject": subject,
        "charecter": charecter,
        "Language": language,
        "Level": level,

    }

    //נשמור את הנתיב לAPI
    const url = baseUrl + "GPT/GPTChat"

//נשמור את הפרמטרים לשליחה
//שיטה מסוג POST
//סוג תוכן: application/json
//body: הנושא (בפורמט JSON)

    const params = {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json'
        },

        // המרת הפרומפט לג׳ייסון
        body: JSON.stringify(prompt)
    }

    //נבצע את קריאת הfetch ונציג את השאלה בHTML
    //שמירה במשתנה מה שחוזר מהשרת
    const response = await fetch(url, params);

    // אם הקריאה בוצעה בהצלחה
    if (response.ok) {
        //המרה לפורמט מתאים
        let data = await response.json();
        data = JSON.parse(data);

        const questionsList = document.getElementById("questions");
        const question = document.createElement("li");
        //חילוץ הערכים
        const questionText = document.createTextNode("The role: " + data["role"]);
        const answerText = document.createTextNode("The opinion: " + data["opinion"]);
        //הצגה בHTML
        question.appendChild(questionText);
        question.appendChild(document.createElement("br"));
        question.appendChild(answerText);
        questionsList.appendChild(question);

    }
 else {
        console.log(errors);
    }

}
