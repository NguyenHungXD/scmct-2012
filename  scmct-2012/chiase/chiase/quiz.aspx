<%@ Page Title="Thi trắc nghiệm" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="quiz.aspx.cs" Inherits="chiase.quiz" %>

<asp:Content ID="QuizStyles" ContentPlaceHolderID="content_slider" runat="server">
</asp:Content>

<asp:Content ID="QuizContent" ContentPlaceHolderID="content_area" runat="server">
    <div class="quiz-container">
        <h2>Thi trắc nghiệm kiến thức về SCMCT</h2>
        <p class="quiz-intro">
            Bài thi nhỏ này giúp bạn ôn lại những thông tin quan trọng về hoạt động của dự án SCMCT.
            Vui lòng chọn một đáp án đúng nhất cho mỗi câu hỏi và nhấn nút <strong>Hoàn thành bài thi</strong> để xem kết quả.
        </p>

        <form id="quiz-form">
            <ol class="quiz-question-list">
                <li class="quiz-question">
                    <h3>SCMCT tập trung vào hoạt động thiện nguyện nào?</h3>
                    <label class="quiz-option"><input type="radio" name="q1" value="A" /> Tổ chức các buổi biểu diễn nghệ thuật gây quỹ.</label>
                    <label class="quiz-option"><input type="radio" name="q1" value="B" /> Quyên góp sách cho trẻ em vùng khó khăn.</label>
                    <label class="quiz-option"><input type="radio" name="q1" value="C" /> Hỗ trợ vay vốn cho sinh viên khởi nghiệp.</label>
                </li>
                <li class="quiz-question">
                    <h3>Thành viên muốn tham gia một dự án trên SCMCT cần thực hiện bước nào?</h3>
                    <label class="quiz-option"><input type="radio" name="q2" value="A" /> Gửi yêu cầu tham gia dự án thông qua trang dự án.</label>
                    <label class="quiz-option"><input type="radio" name="q2" value="B" /> Liên hệ trực tiếp bằng điện thoại với quản trị viên.</label>
                    <label class="quiz-option"><input type="radio" name="q2" value="C" /> Đợi được mời qua thư điện tử.</label>
                </li>
                <li class="quiz-question">
                    <h3>Trang &ldquo;Tin tức&rdquo; của SCMCT dùng để làm gì?</h3>
                    <label class="quiz-option"><input type="radio" name="q3" value="A" /> Chia sẻ bài viết, thông tin mới nhất về các hoạt động.</label>
                    <label class="quiz-option"><input type="radio" name="q3" value="B" /> Lưu trữ hồ sơ cá nhân của thành viên.</label>
                    <label class="quiz-option"><input type="radio" name="q3" value="C" /> Bán các vật phẩm gây quỹ.</label>
                </li>
                <li class="quiz-question">
                    <h3>Tại sao nên đăng nhập khi truy cập SCMCT?</h3>
                    <label class="quiz-option"><input type="radio" name="q4" value="A" /> Để xem được tất cả hình ảnh ở độ phân giải cao.</label>
                    <label class="quiz-option"><input type="radio" name="q4" value="B" /> Để quản lý hồ sơ cá nhân, tham gia dự án và theo dõi đóng góp.</label>
                    <label class="quiz-option"><input type="radio" name="q4" value="C" /> Để nhận thông báo qua SMS.</label>
                </li>
                <li class="quiz-question">
                    <h3>Chức năng &ldquo;Chia sẻ&rdquo; trên SCMCT giúp bạn làm gì?</h3>
                    <label class="quiz-option"><input type="radio" name="q5" value="A" /> Đề xuất thêm loại sách mới cho thư viện.</label>
                    <label class="quiz-option"><input type="radio" name="q5" value="B" /> Đăng tải yêu cầu hỗ trợ sách hoặc vật dụng cho dự án.</label>
                    <label class="quiz-option"><input type="radio" name="q5" value="C" /> Tạo trang cá nhân cho nhóm thiện nguyện riêng.</label>
                </li>
            </ol>

            <div class="quiz-actions">
                <button type="button" class="quiz-submit" onclick="evaluateQuiz()">Hoàn thành bài thi</button>
                <button type="reset" class="quiz-reset">Làm lại</button>
            </div>
        </form>

        <div id="quiz-result" class="quiz-result" aria-live="polite"></div>
    </div>

    <script type="text/javascript">
        (function () {
            var answerKey = {
                q1: "B",
                q2: "A",
                q3: "A",
                q4: "B",
                q5: "B"
            };

            var form = document.getElementById("quiz-form");
            var resultContainer = document.getElementById("quiz-result");

            var resetHandler = function () {
                resultContainer.className = "quiz-result";
                resultContainer.innerHTML = "";
                resultContainer.style.display = "none";
            };

            if (form.addEventListener) {
                form.addEventListener("reset", resetHandler);
            } else if (form.attachEvent) {
                form.attachEvent("onreset", resetHandler);
            } else {
                form.onreset = resetHandler;
            }

            window.evaluateQuiz = function () {
                var total = 0;
                var correct = 0;
                var unanswered = [];

                for (var question in answerKey) {
                    if (!answerKey.hasOwnProperty(question)) {
                        continue;
                    }

                    total++;
                    var selectedValue = null;
                    var inputs = form.elements[question];

                    if (inputs && inputs.length === undefined) {
                        if (inputs.checked) {
                            selectedValue = inputs.value;
                        }
                    } else if (inputs) {
                        for (var i = 0; i < inputs.length; i++) {
                            if (inputs[i].checked) {
                                selectedValue = inputs[i].value;
                                break;
                            }
                        }
                    }

                    if (!selectedValue) {
                        unanswered.push(question);
                        continue;
                    }

                    if (selectedValue === answerKey[question]) {
                        correct++;
                    }
                }

                if (unanswered.length > 0) {
                    resultContainer.className = "quiz-result quiz-result--warning";
                    resultContainer.innerHTML = "Vui lòng trả lời tất cả câu hỏi trước khi nộp bài.";
                    resultContainer.style.display = "block";
                    return;
                }

                var score = Math.round((correct / total) * 100);
                var message = "";

                if (score === 100) {
                    message = "Tuyệt vời! Bạn đã hiểu rất rõ về SCMCT.";
                } else if (score >= 60) {
                    message = "Rất tốt! Bạn đã nắm khá nhiều thông tin. Hãy đọc thêm để đạt điểm tuyệt đối.";
                } else {
                    message = "Bạn cần tìm hiểu thêm về SCMCT. Ghé thăm các trang Giới thiệu và Tin tức để cập nhật thông tin.";
                }

                resultContainer.className = "quiz-result quiz-result--success";
                resultContainer.innerHTML = "Bạn trả lời đúng " + correct + "/" + total + " câu (" + score + "%). " + message;
                resultContainer.style.display = "block";
            };
        })();
    </script>
</asp:Content>
