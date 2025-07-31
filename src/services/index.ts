import axios from "axios"
const api = import.meta.env.VITE_API_BACKEND_URL;
const api_bank = import.meta.env.VITE_BANK_API_KEY;
const api_bank_url = import.meta.env.VITE_API_BANK_URL;

//login , sign up
export const login = async (email: string, password: string) => {
    const res = await axios.post(`${api}/users/signin`, {
        email,
        password,
    });
    localStorage.setItem("user", JSON.stringify(res.data.data));
    return res.data;
};

export const register = async (username: string, email: string, password: string) => {
    try {
        const res = await axios.post(`${api}/users/signup`, {
            username,
            email,
            password,
        });
        return { success: true, data: res.data };
    } catch (err: any) {
        return { success: false, error: err.response?.data || "Đăng ký thất bại" };
    }
};

//users
export const getUser = async () => {
    const res = await axios.get(`${api}/users`)
    return res.data
}
export const editUser = async (userId:number,fullName:string,email:string,password:string,phone:string) => {
    const res = await axios.put(`${api}/users/updateUser/${userId}`, {
        fullName,
        email,
        password,
        phone,
    })
    return res.data
}
export const deleteUser = async (id : number) => {
    const res = await axios.delete(`${api}/users/${id}`)
    return res.data
}

export const getTeacher = async () => {
    const res = await axios.get(`${api}/users/getTeacher`)
    return res.data
}

//Courses
export const getCourses = async () => {
    const res = await axios.get(`${api}/courses`)
    return res.data
};
export const getCourseById = async (id: number) => {
    const res = await axios.get(`${api}/courses/${id}`)
    return res.data
}

export const getCourseByName = async (name: string) => {
    const encodedName = encodeURIComponent(name);
    const res = await axios.get(`${api}/courses/name?name=${encodedName}`);
    return res.data;
};
export const getCourserbyUserId = async (userid: number) => {
    const res = await axios.get(`${api}/carts/${userid}`)
    return res.data
}
export const getCourseOff = async () =>{
    const res = await axios.get(`${api}/courses/offline`)
    return res.data
}
export const getCatalogs = async () =>{
    const res = await axios.get(`${api}/catalogs`)
    return res.data
}
export const getCourseByCatalogs = async (id:number,num:number) =>{
    const res = await axios.get(`${api}/courses/byCatalog?catalogId=${id}&num=${num}`)
    return res.data
}
export const addCourse = async (titleVI:string,titleEN:string,desVI:string,desEN:string,countday:number,price:number,mode:string,img:string) =>{
    const res = await axios.post(`${api}/courses/addCourse`,{
        titleVI,
        titleEN,
        desVI,
        desEN,
        countday,
        price,
        mode,
        img,
    })
    return res.data
}
export const updateCourse = async (id: number, data: any) => {
  const res = await axios.put(`${api}/courses/${id}`, data)
  return res.data
}
export const deleteCourse = async (id : number) => {
    const res = await axios.delete(`${api}/courses/${id}`)
    return res.data
}
//Sections
export const addSection = async (data:any) =>{
    const res = await axios.post(`${api}/sections/addSection`,data)
    return res.data
}
export const updateSection = async (id:number,data:any) =>{
    const res = await axios.put(`${api}/sections/${id}`,data)
}
//lessons
export const getLessons = async (id: number) => {
    const res = await axios.get(`${api}/lessons/${id}`)
    return res.data
}

//Carts
export const addCarts = async (users_id: number, course_id: number) => {
    const res = await axios.post(`${api}/carts/addCourse`, {
        users_id,
        course_id,
    })
    return res.data
}

export const deletecarts = async (coursesid: number, userid: number) => {
    const res = await axios.delete(`${api}/carts/${coursesid}/${userid}`)
    return res.data
}

// Xóa nhiều khóa học khỏi cart
export const deleteMultipleCarts = async (courseIds: number[], userId: number) => {
    const promises = courseIds.map(courseId => deletecarts(courseId, userId));
    return Promise.all(promises);
}

export const getEnrollments = async (student_id: number) => {
    const res = await axios.get(`${api}/enrollments/getEnrollmentByUserId/${student_id}`)
    return res.data;
}

export const addEnrollments = async (student_id: number, courses_id: number) => {
    try {
        const res = await axios.post(`${api}/enrollments/addEnrollment`, {
            student_id,
            courses_id,
        });
        return res.data;
    } catch (error: any) {
        if (error.response?.status === 409) {
            console.log('⚠️ User đã đăng ký khóa học này rồi');
            // Trả về success để không block luồng
            return { success: true, message: 'Đã đăng ký trước đó' };
        }
        throw error;
    }
}

export const getReview = async (courseid: number) => {
    const res = await axios.get(`${api}/reviews/${courseid}`)
    return res.data;
}

export const getComment = async (lessonid: number) => {
    const res = await axios.get(`${api}/comments/${lessonid}`)
    return res.data;
}
export const addComment = async (lesson_id: number, user_id: number, text: string,parent_id: number | null = null) => {
    const res = await axios.post(`${api}/comments/addComment`, {
        lesson_id,
        user_id,
        text,
        parent_id
    })
    return res.data;
}
export async function getNotebylesson(lesson_id: number, user_id: number) {
    const res = await axios.get(`${api}/lessonNotes/lessonNoteByUser?userId=${user_id}&lessonId=${lesson_id}`)
    return res.data;
}
export async function addNote(lesson_id: number, user_id: number,text: string,video_time: string) {
    const res = await axios.post(`${api}/lessonNotes/addLessonNote`,{
        lesson_id,
        user_id,
        text,
        video_time
    })
    return res.data;
}

export async function deleteNote(id: number) {
    const res = await axios.delete(`${api}/lessonNotes/delete/${id}`);
    return res.data;
}
export async function checkPaid(amount: number, content: string): Promise<boolean> {
    try {
        const res = await fetch("https://script.google.com/macros/s/AKfycbyWBmLcRs10yWLJDCBzlTx9SVAnHxMn0pnNudd6_6cdfjFZJdI90lMlzKh9XCqQUDxQXQ/exec");
        const resdata = await res.json();
        const transactions = resdata.data;

        const expectedContent = content.toLowerCase().trim();

        for (const tran of transactions) {
            const amountPaidRaw = tran["Giá trị"];
            const descRaw = tran["Mô tả"] || "";

            const amountPaid = parseInt(String(amountPaidRaw).replace(/[^0-9]/g, '')) || 0;
            const desc = descRaw.toLowerCase().trim();

            console.log(`🧾 Kiểm tra giao dịch: amount=${amountPaid}, desc=${descRaw}`);

            if (amountPaid >= amount && desc.includes(expectedContent)) {
                console.log("✅ Đã tìm thấy giao dịch phù hợp!");
                return true;
            }
        }

        console.log("❌ Không tìm thấy giao dịch phù hợp.");
        return false;
    } catch (error) {
        console.error("Lỗi kiểm tra thanh toán:", error);
        return false;
    }
}

export async function translateViEn(text: string): Promise<string> {
    const res = await fetch("https://libretranslate.de/translate", {
        method: "POST",
        body: JSON.stringify({
            q: text,
            source: "auto",
            target: "en",
            format: "text",
            api_key: ""
        }),
        headers: { "Content-Type": "application/json" }
    });

    const data = await res.json();
    console.log("Kết quả dịch:", data);
    return data.translatedText;
}
export const getTopic = async () => {
    const res = await axios.get(`${api}/topics`)
    return res.data;
}
export const getVocabulary = async (topicId: number) => {
    const res = await axios.get(`${api}/vocabularies/${topicId}`)
    return res.data;
}
//Points
export const getPoints = async (userId: number) => {
    const res = await axios.get(`${api}/users/level/${userId}`)
    return res.data;
}

//Ranks
export const getRank = async () => {
    const res = await axios.get(`${api}/users/rankings`)
    return res.data;
}


export const addUserLesson = async (student_id: number, lessonsId: number) => {
    const res = await axios.post(`${api}/userlesson/addUserLesson`, {
        student_id,
        lessonsId
    });
    return res.data;
}

// UserLesson APIs
export const getUserLessons = async (userId: number) => {
    const res = await axios.get(`${api}/userlesson/${userId}`);
    return res.data;
}

export const getUserLessonsByUserId = async (userId: number) => {
    const res = await axios.get(`${api}/userlesson/${userId}`);
    return res.data;
}

// Vocabulary APIs
export const createVocabulary = async (data: any) => {
    const res = await axios.post(`${api}/vocabularies/addVocabulary`, data);
    return res.data;
}

export const updateVocabulary = async (id: number, data: any) => {
    const res = await axios.put(`${api}/vocabularies/${id}`, data);
    return res.data;
}

export const deleteVocabulary = async (id: number) => {
    const res = await axios.delete(`${api}/vocabularies/${id}`);
    return res.data;
}

// Task APIs
export const getTasks = async (userId: number) => {
    const res = await axios.get(`${api}/tasks/${userId}`);
    return res.data;
}

export const createTask = async (data: any) => {
    const res = await axios.post(`${api}/tasks/addTask`, data);
    return res.data;
}

export const updateTask = async (id: number, data: any) => {
    const res = await axios.put(`${api}/tasks/${id}`, data);
    return res.data;
}

export const deleteTask = async (id: number) => {
    const res = await axios.delete(`${api}/tasks/${id}`);
    return res.data;
}

// Schedule APIs
export const getSchedules = async (userId: number) => {
    const res = await axios.get(`${api}/schedules/user/${userId}`);
    return res.data;
}

export const getSchedulesByCourse = async (userId: number, courseId: number) => {
    const res = await axios.get(`${api}/schedules/user/${userId}/course/${courseId}`);
    return res.data;
}

export const createSchedule = async (data: {
    studentId: number;
    courses_id: number;
    dayOfWeek: string;
    timeLearn: string;
}) => {
    const res = await axios.post(`${api}/schedules`, data);
    return res.data;
}

export const deleteSchedule = async (userId: number, courseId: number) => {
    const res = await axios.delete(`${api}/schedules/user/${userId}/course/${courseId}`);
    return res.data;
}

// Teacher APIs
export const getTeachers = async () => {
    const res = await axios.get(`${api}/users/getTeacher`);
    return res.data;
}

export const getTeacherById = async (id: number) => {
    const res = await axios.get(`${api}/users/${id}`);
    return res.data;
}

