# SilverhorseRecruitmentTest
Updated Repository for my Silverhorse Recruitment Test<br />

<br />

Motivations: To show my skills in Web Development<br />

How to Run: Clone or download this zip in Visual Studio 2022 and run. Once running, click the 'Authorize' Button and pass in 'Bearer af24353tdsfw'.<br />

Challenges: I'd never personally done any authenticating before, thus the Bearer authentication was slightly challenging<br />

Known Issues:

      - Authentication does work, however It doesn't state when the passed in token is incorrect, and will always output 'approved' even if the password is incorrect
      
      - Authentication issues return 401 not 501
      
      - Some of the posts CRUD works when it shouldn't (ie. trying to delete a post that doesn't exist)
