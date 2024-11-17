// רשימה של ספורט
const jsonData = {
    "sports": [
        {
            "id": 1,
            "title": "כדורגל",
            "content": "כדורגל (הלחם של כדור ורגל) הוא ענף הספורט הקבוצתי הפופולרי והנפוץ ביותר בעולם. במשחק משתתפות שתי קבוצות, שמטרת כל אחת מהן היא הכנסת כדור המשחק לתוך שערהּ של השנייה. כל קבוצה מונה אחד עשר שחקנים, אם כי ישנן גרסאות שבהן מספר נמוך יותר של משתתפים ובין מקורות המשחק גם גרסאות המוניות. הכדורגל נחשב לספורט הפופולרי ביותר בעולם: כ-240 מיליון איש ברחבי העולם משחקים כדורגל באופן סדיר, בין אם באופן מקצועני ובין אם חובבני. במסגרת הענף פועלים כ-300,000 מועדונים מקצועיים, הרשומים בגופים הרשמיים המנהלים אותו.",
            "img": "soccer.png",
            "category": "team sport",
            
        },
        {
            "id": 2,
            "title": "כדורסל",
            "content": "בכדורסל, שחקני הקבוצה מתמקדים בשימוש בכישורים שונים כגון כישורי זריקה מדויקת, קפיצות גבוהות לחילוף זריקות וחילוף סחובים, וכן ריצה מהירה ורעננות לניהול המשחק באופן אסטרטגי. המשחק מאתגר את השחקנים להיות מהירים בחשיבה ובתגובה תוך שמירה על שליטה מדויקת בכדור ובתנועה סביב המגרש.",
            "img": "basketball.png",
            "category": "team sport",
        },
        {
            "id": 3,
            "title": "טניס",
            "content": "טניס הוא משחק אינדיבידואלי אך גם קבוצתי בו השחקן מתמקד בביצועים האישיים שלו, אך גם ביכולת לקרוא את המשחק ולהתאים את האסטרטגיה שלו בהתאם ליריב. התנגדות ללחץ ואינטנסיביות פיזית מאתגרים את השחקן, וכן דרישה לכושר גופני גבוה.",
            "img": "tennis.png",
            "category": "single sport",
        },
        {
            "id": 4,
            "title": "כדור עף",
            "content": "כדורעף הוא משחק תחרותי המשוחק בין שתי קבוצות, ומטרתו להפיל את הכדור במגרשה של היריבה. האתגר הוא שאי אפשר לתפוס את הכדור. לפיכך, לכל קבוצה מותרות עד 3 נגיעות רצופות בכדור עד להעברתו לקבוצה היריבה מעל הרשת. שחקן מסויים לא יכול לגעת בכדור פעמיים ברציפות. כמו כן, מותר השימוש בכל איבר בגוף. זהו ספורט אולימפי",
            "img": "volleyball.png",
            "category": "team sport",
        },
        {
            "id": 5,
            "title": "קרוספיט",
            "content": "קרוספיט הוא אימון פיזי המשלב תרגילים פיזיים שונים כמו ריצה, קפיצות, ותרגילים במשקולות. האימון מאתגר את הגוף והנפש ודורש יציבות וכוח רציניים. הוא דורש יציבות רגשית ורצון להתמודד עם אתגרים פיזיים קשים.",
            "img": "crossfit.png",
            "category": "single sport",
        },
        {
            "id": 6,
            "title": "התעמלות אומנותית",
            "content": "התעמלות אומנותית היא סוג של ספורט המשלב בין גמישות, כוח, ואסתטיקה. המתרגלים בוחרים בתרגילים מורכבים ומגוונים הדורשים שליטה רבה על גופם, וכוללים קפיצות, קיפולים, תרגילי חוזק וגמישות, ותרגילים במקום פתוח וגבוה. התעמלות אומנותית מציעה אתגרים פיזיים ומנטליים, ומכוונת לשיפור כוח, גמישות, יציבות, ומיומנויות איזון.",
            "img": "Artistic Gymnastics.png",
            "category": "single sport",
        },
        {
            "id": 7,
            "title": "התעמלות מכשירים",
            "content": "התעמלות מכשירים היא סוג של אימון פיזי המתבצע בעיקר באמצעות שימוש בציוד ומכשירים כגון ברים, משקולות, כורסאות כוח ועוד. האימון מתמקד בחיזוק שרירי הגוף, פיתוח כוח וגמישות, ושיפור הכושר הפיזי. נתוני האימון כוללים מספר הסטים, כמות החזרות, והמשקולת המשומשת בכל תרגול. התעמלות מכשירים מתאימה לשיפור כושר גופני, בניית שרירים, והפחתת כמות השומן בגוף.",
            "img": "Gymnastics apparatus.png",
            "category": "single sport",
        },
        {
            "id": 8,
            "title": "פוטצ'יוולי",
            "content": "משחק דמוי כדורעף חופים המשוחק עם כל חלקי הגוף חוץ מהידיים – החזה, הכתף, הראש והרגליים. שני שחקנים בכל קבוצה צריכים לגרום לכדור לפגוע בקרקע של הקבוצה השנייה במקסימום של 2 מסירות בניהם. משחק אשר המקור שלו הוא בדרום אמריקה - ברזיל.",
            "img": "Puccivelli.png",
            "category": "team sport",
        },
        {
            "id": 9,
            "title": "פוטבול",
            "content": "הוא משחק כדור קבוצתי המשלב כוח, מהירות, זריזות, טכניקה ואגרסיביות במטרה להכניס את הכדור לאזור בסוף שטח הקבוצה היריבה המכונה אנד זון (End Zone). מקורו של המשחק - בדומה למשחק הכדורגל - הוא במשחקי כדור שהיו נפוצים באנגליה במאה ה-19.",
            "img": "Football.png",
            "category": "team sport",
        },
        {
            "id": 10,
            "title": "שחיה",
            "content": "שחייה תחרותית היא ענף ספורט אולימפי שמתבסס על שחייה עממית. המטרה בשחייה תחרותית היא לקבוע את הזמן המהיר ביותר. שחייה, יחד עם אתלטיקה והתעמלות, נחשבים לענפי הספורט הפופולריים ביותר במשחקים האולימפיים",
            "img": "swimming.png",
            "category": "single sport",
        }
        ]
}



//לאחר טעינת העמוד
document.addEventListener("DOMContentLoaded", function (event) {
    // קריאה לפונקציה שתיצור את הרשימה אחרי עליית העמוד
    createItems()
});



function createItems() {
    const listContainer = document.getElementById("itemsContainer");
    const list = document.createElement("ul");
    list.setAttribute("id", "UL-container");

    jsonData.sports.forEach((sport) => {
        const listItem = document.createElement("li");
        listItem.setAttribute("id", `li_${sport.id}`);
        listItem.setAttribute("data-title", sport.title);
        

        const sportPic = document.createElement("img");
        sportPic.setAttribute("src", `img/${sport.img}`);
        listItem.appendChild(sportPic);

        const liTitle = document.createElement("h2");
        liTitle.appendChild(document.createTextNode(sport.title));
        listItem.appendChild(liTitle);

    
        // const moreInfoButton = document.createElement("button");
        // moreInfoButton.appendChild(document.createTextNode("למידע נוסף"));
        // moreInfoButton.addEventListener("click", () => clickedTopic(c.id)); // כפתור המיועד לפתיחת פופ אפ עם מידע נוסף
        // listItem.appendChild(moreInfoButton);

        listItem.addEventListener("click", function () {
        showSportDetails(sport);
        });

        list.appendChild(listItem);

    });

    listContainer.appendChild(list);
}



function toggleNav() {
    var navLinks = document.getElementById("navLinks");
    var navIcon = document.getElementById("navIcon");

    navLinks.classList.toggle("open");

    // Toggle between hamburger and "x" symbols
    if (navLinks.classList.contains("open")) {
        navIcon.textContent = "✕"; // "x" symbol
    } else {
        navIcon.textContent = "☰"; // hamburger symbol
    }
}



// searching items based on user input.
function searchItems() {
    const searchInput = document.getElementById("sportInput");
    const searchQuery = searchInput.value.toLowerCase();

    const items = document.querySelectorAll("#itemsContainer li");

    items.forEach((item) => {
        const itemTitle = item.getAttribute("data-title");

        if (itemTitle.includes(searchQuery)) {
            item.style.display = "list-item";
        } else {
            item.style.display = "none";
        }
    });
}


// filtering items based on tags
function filterSport(category) {
    const searchInput = document.getElementById("sportInput");
    searchInput.value = ""; // Clear the search input
    const sportsItems = document.querySelectorAll("#itemsContainer li");

    sportsItems.forEach((sport) => {
        const sportId = sport.id.replace("li_", "");
        const sportCategory = jsonData.sports.find((sport) => sport.id.toString() === sportId).category;

        if (category === "All" || sportCategory === category) {
            sport.style.display = "list-item";
        } else {
            sport.style.display = "none";
        }
    });

}


//פופאפ
function showSportDetails(sport) {
    const modalTitle = document.getElementById("modalTitle");
    const modalContent = document.getElementById("modalContent");
    const modalImage = document.getElementById("modalImage");

    modalTitle.innerHTML = sport.title;
    modalContent.innerHTML = sport.content;
    modalImage.setAttribute("src", `img/${sport.img}`);

    // Use Bootstrap's modal method to show the modal
    var myModal = new bootstrap.Modal(document.getElementById('myModal'));
    myModal.show();
}