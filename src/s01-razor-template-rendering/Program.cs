using ConsoleRazorRenderer.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;

var provider = new ServiceCollection()
    .AddLogging()
    .AddTransient<HtmlRenderer>()
    .AddTransient<NewsletterRenderer>()
    .BuildServiceProvider();

var content = new NewsletterComponent.NewsletterDto(
    Title: "Pre NTK - DevOps Edition",
    // language=html
    Content: new("""
                 </span>Announcing first in a line of events leading up to the biggest local development conference <em>#NTK24</em>
                     <br />
                     <strong>Pre 𝗡𝗧𝗞 - 𝗗𝗲𝘃Ops 𝗘𝗱𝗶𝘁𝗶𝗼𝗻 PART 1!</strong>
                     <br /> <br />
                     
                 <strong><a href="https://slodug.si/dogodki/pre-ntk-part1">Pre NTK DevOps Edition - Part 1</a></strong>
                 <div class="v-text-align v-font-size"
                      style="font-size: 12px; line-height: 140%; text-align: left; word-wrap: break-word; padding-left: 20%;">
                     🗓️ WHEN: Wednesday, January 17th 2024, at 6PM<br />
                     📍 WHERE: BTC City Ljubljana<br />
                     🔗 <a href="https://www.meetup.com/1337-tech-ljubljana/events/297960765/">Sign up here</a><br/>
                 </div>
                 <br/><br/>
                 <div>
                     <h3>Agenda:</h3>
                     <p>🎙 <b>Fist talk - short description [author]</p>
                     <p>🎙 <b>Second talk - short description [another author]</p>
                 </div>
                 <br/>
                 See you there!
                 <br/>
                 """),
    HeadingImageUrl: "https://slodug.blob.core.windows.net/uploads/a9424857-0326-49a4-bbb0-b89ecb9a1038/SloDug_wide_empty.png");

var renderer = provider.GetRequiredService<NewsletterRenderer>();
var newsletterHtml = await renderer.RenderHtml(content);
// do something with the content here
