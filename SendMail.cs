//在.net core 下没有System.Net.Mail命名空间, 这份代码在.net framwork (4.6)之前是可以用的
//演示了一种最简单的发送邮件的方法
//测试通过
// using System;
// using System.Net;
// using System.Net.Mail;

// namespace ConsoleApplication
// {
//     public class SendMailClass
//     {
//         public void print()
//         {	
//             string mfrom = "zkhost@163.com";//发件人, 只能跟下面认证的邮箱一致
//             string mto = "1014336691@qq.com";
//             string msubject = "来自zkhost的测试邮件";
//             string mbody = "这是一封测试邮件, 请不要回复!";
//             if (SendMail(mfrom, mto, msubject, mbody))
//                 Console.WriteLine("发送成功");
//             else
//                 Console.WriteLine("发送失败");
//         }

//         public bool SendMail(string mfrom, string mto, string msubject, string mbody)
//         {
//             MailMessage mail = new MailMessage(mfrom, mto, msubject, mbody);
//             //mail.Attachments.Add(new Attachment("string filename"));//附件-->可以添加当前目录下的文件
// 		    //mail.CC.Add("fangchaozeng@163.com");  抄送
//             SmtpClient smtp = new SmtpClient();
//             smtp.Host = "smtp.163.com";//邮件服务器
//             smtp.Port = 25;//认证端口
//             smtp.UseDefaultCredentials = true;
//             smtp.Credentials = new NetworkCredential("zkhost@163.com", "hostzk1");//认证邮箱
//             try
//             {
//                 smtp.Send(mail);
//                 return true;
//             }
//             catch(Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return false;
//             }
//         }
//     }
// }