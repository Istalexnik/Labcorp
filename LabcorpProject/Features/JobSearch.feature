Feature: Searching and Applying for a Job

Scenario: Search and Apply for a Job
  Given I am on the home page
  When I go to the Careers page
  And I search for 'Lead Automation Engineer' on the Jobs page
  And I click on the job with title 'Lead Automation Engineer'
  Then the job title should be 'Lead Automation Engineer'
  And the job location should be 'Burlington, North Carolina, United States of America'
  And the job ID should be '2336785'
  And the job requirements should include '3+ years experience with QA automation or 3 years experience as a Software Engineer (Backend, Frontend, Mobile etc.)'
  And the bonus points should include 'Selenium'
  And the job offers should include:
    | Offer                                                                                        |
    | Small, dynamic and tight-knit teams that encompass a supportive and collaborative atmosphere |
    | Growth and education stipend                                                                 |
    | Flexible work schedule                                                                       |
    | Unlimited paid vacation and sick leave                                                       |
    | Four options for medical insurance coverage                                                  |
    | Dental, and vision as well as many other wellness-centered benefits                          |
    | Employer contribution to 401k with immediate vesting plan                                    |
    | Paid parental leave                                                                          |
    | Ability to be fully remote                                                                   |
  When I click the Apply button
  Then I decline the legal notice
  And I return to the Careers home
