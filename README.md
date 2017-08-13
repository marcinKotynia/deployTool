# deployTool

## How To setup CI using DeployTool and Github

### Step 1 Install Deploy tool on your IIS server

### Step 2 Configure your site must be visible in Internet

[get] 	/fetch/[repositoryname]
[post]	/fetch/[repositoryname]
[get] 	/command/[repositoryname]
[post]	/command/[repositoryname]
### Step 3

- repositoryName: platforma
  repositoryPath: C:\git\csvtosql
  username: test
  password: test

#### Step 4 Optional Deploy Key (Github) 

- Run Git Bash on server create certificate
~~~
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
~~~


- Github > Project > Settings > Deploy Key
- Github Paste Public key to deploy key
- Optional start ssh agent if "Could not open a connection to your authentication agent."
You might need to start ssh-agent before you run the ssh-add command:

~~~
eval `ssh-agent -s`
~~~
- add newly created key 
~~~
key ssh-add ~/.ssh/id_rsa
~~~




#### Step 5 (use ssl version with Key)
git clone [your repository]   


  
## Step 4 Github Setup 

### 





